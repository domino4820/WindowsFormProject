using Flappy_Bird_Game;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Helpers;
using PayPal.Api;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherGames
{
    public partial class PaypalForm : Form
    {
        private TransactionForm mainForm;
        private string paymentId;
        private string payerId;
        private readonly IUserService _userService;
        private readonly int _userId;

        public PaypalForm(IUserService userService, int userId, TransactionForm form)
        {
            InitializeComponent();
            _userService = userService;
            _userId = userId;
            mainForm = form;
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (cmbMenhgia.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mệnh giá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedAmount = cmbMenhgia.SelectedItem.ToString();
            var payment = CreatePayment(selectedAmount);

            paymentId = payment.id;

            var approvalUrl = GetApprovalUrl(payment);

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = approvalUrl,
                    UseShellExecute = true
                });

                MessageBox.Show("Vui lòng hoàn tất thanh toán trên trang PayPal. Sau khi hoàn tất, quay lại ứng dụng và nhập Payer ID để kiểm tra thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi mở URL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Payment CreatePayment(string amount)
        {
            var apiContext = PayPalConfiguration.GetAPIContext();

            var payer = new Payer() { payment_method = "paypal" };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = "https://www.paypal.com/cancel",
                return_url = "https://www.paypal.com/success"
            };

            var itemList = new ItemList()
            {
                items = new List<Item>()
                {
                    new Item()
                    {
                        name = "Nạp tiền",
                        currency = "USD",
                        price = amount,
                        quantity = "1",
                        sku = "sku"
                    }
                }
            };

            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = amount
            };

            var paymentAmount = new Amount()
            {
                currency = "USD",
                total = amount,
                details = details
            };

            var transactionList = new List<Transaction>
            {
                new Transaction()
                {
                    description = "Nạp tiền vào tài khoản",
                    invoice_number = Guid.NewGuid().ToString(),
                    amount = paymentAmount,
                    item_list = itemList
                }
            };

            var payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }

        private static string GetApprovalUrl(Payment payment)
        {
            var approvalUrl = payment.links.FirstOrDefault(l => l.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));
            return approvalUrl?.href;
        }

        private async void btnCheckPayment_Click(object sender, EventArgs e)
        {
            var apiContext = PayPalConfiguration.GetAPIContext();

            if (string.IsNullOrEmpty(paymentId))
            {
                MessageBox.Show("Không tìm thấy Payment ID. Vui lòng thực hiện thanh toán trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var inputForm = new InputForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    payerId = inputForm.PayerId;
                }
            }

            if (string.IsNullOrEmpty(payerId))
            {
                MessageBox.Show("Payer ID không hợp lệ. Vui lòng nhập Payer ID.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var paymentExecution = new PaymentExecution() { payer_id = payerId };
                var payment = new Payment() { id = paymentId };

                var executedPayment = payment.Execute(apiContext, paymentExecution);

                if (executedPayment.state.ToLower() == "approved")
                {
                    decimal amount = decimal.Parse(executedPayment.transactions.First().amount.total);
                    await _userService.AddBalanceAsync(_userId, amount);

                    MessageBox.Show("Thanh toán thành công và số dư đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thanh toán không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi kiểm tra thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            mainForm.Show();
        }
    }
}