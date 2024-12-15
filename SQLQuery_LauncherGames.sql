create database LauncherGames
ON
	(
	Name= 'LauncherGames_Dat',
	FILENAME = 'C:\LauncherGames\LauncherGames.MDF',
	SIZE = 5,
	MAXSIZE = 50,
	FILEGROWTH = 5	
	)
LOG ON
	(
	Name= 'QLBH_DATA',
	FILENAME = 'C:\LauncherGames\LauncherGames.LDF',
	SIZE = 10,
	MAXSIZE = 100,	
	FILEGROWTH = 5
	);

USE LauncherGames

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL,
    Balance DECIMAL(18, 2) DEFAULT 0.00,
    CreatedAt DATETIME DEFAULT GETDATE()
	FullName NVARCHAR(100),
    PhoneNumber NVARCHAR(15),
    Email NVARCHAR(100);
);

CREATE TABLE Games (
    GameId INT PRIMARY KEY IDENTITY(1,1),
    GameName NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Genre NVARCHAR(50),
    ReleaseDate DATE,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Transactions (
    TransactionId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    GameId INT NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (GameId) REFERENCES Games(GameId)
);
USE LauncherGames;
GO

--test chức năng giao dịch
SELECT UserId FROM dbo.Users WHERE Username = 'username'; --tên người dùng khi đăng kí
SELECT GameId FROM dbo.Games WHERE GameName = 'Washmouth'; --tên game

INSERT INTO dbo.Games (GameName, Price, Genre, ReleaseDate, CreatedAt)
VALUES ('MothWash', 50.00, 'Adventure', GETDATE(), GETDATE());

INSERT INTO dbo.Transactions (UserId, GameId, Amount, TransactionDate)
VALUES (
    (SELECT UserId FROM dbo.Users WHERE Username = 'domino987'),
    (SELECT GameId FROM dbo.Games WHERE GameName = 'MothWash'),
    50.00,
    GETDATE()
);