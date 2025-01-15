CREATE DATABASE my_database;

CREATE TABLE IF NOT EXISTS Customer (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15),
    Address VARCHAR(255),
    City VARCHAR(50),
    State VARCHAR(50),
    PostalCode VARCHAR(10),
    Country VARCHAR(50),
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Customer (Name, Email, PhoneNumber, Address, City, State, PostalCode, Country, IsActive) VALUES
('Alice Johnson', 'alice.johnson@example.com', '123-456-7890', '123 Elm St', 'New York', 'NY', '10001', 'USA', TRUE),
('Bob Smith', 'bob.smith@example.com', '234-567-8901', '456 Oak St', 'Los Angeles', 'CA', '90001', 'USA', TRUE),
('Charlie Brown', 'charlie.brown@example.com', '345-678-9012', '789 Pine St', 'Chicago', 'IL', '60601', 'USA', FALSE),
('Diana Prince', 'diana.prince@example.com', '456-789-0123', '321 Maple St', 'Houston', 'TX', '77001', 'USA', TRUE),
('Eve Adams', 'eve.adams@example.com', '567-890-1234', '654 Cedar St', 'Phoenix', 'AZ', '85001', 'USA', TRUE),
('Frank Castle', 'frank.castle@example.com', '678-901-2345', '987 Birch St', 'Philadelphia', 'PA', '19101', 'USA', FALSE),
('Grace Hopper', 'grace.hopper@example.com', '789-012-3456', '159 Walnut St', 'San Antonio', 'TX', '78201', 'USA', TRUE),
('Hank Pym', 'hank.pym@example.com', '890-123-4567', '753 Spruce St', 'San Diego', 'CA', '92101', 'USA', TRUE),
('Ivy Green', 'ivy.green@example.com', '901-234-5678', '357 Cypress St', 'Dallas', 'TX', '75201', 'USA', FALSE),
('Jack Sparrow', 'jack.sparrow@example.com', '012-345-6789', '951 Palm St', 'Austin', 'TX', '73301', 'USA', TRUE);
