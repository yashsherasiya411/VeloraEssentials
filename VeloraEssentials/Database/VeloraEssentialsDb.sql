-- Optional: run this in SSMS if you want to create the database manually.
-- The application also creates the database automatically on first run.
CREATE DATABASE VeloraEssentialsDb;
GO
USE VeloraEssentialsDb;
GO
CREATE TABLE Products (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Name          NVARCHAR(100)  NOT NULL,
    Description   NVARCHAR(500)  NULL,
    Category      NVARCHAR(50)   NOT NULL,
    Price         DECIMAL(10,2)  NOT NULL,
    StockQuantity INT            NOT NULL,
    ImageUrl      NVARCHAR(300)  NULL,
    IsActive      BIT            NOT NULL DEFAULT 1
);
GO
INSERT INTO Products (Name, Description, Category, Price, StockQuantity) VALUES
('Organic Cotton Pads (Regular)', 'Soft, breathable cotton pads for everyday comfort.', 'Pads', 199, 50),
('Menstrual Cup', 'Reusable medical-grade silicone cup.', 'Cups', 399, 25),
('Panty Liners', 'Thin daily liners for light days.', 'Liners', 99, 80);
GO
-- Note: if you create the database manually, skip db.Database.EnsureCreated() in Program.cs
-- (EnsureCreated does nothing when the database already has tables).
