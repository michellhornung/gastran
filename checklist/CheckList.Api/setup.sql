-- Criação da base de dados
CREATE DATABASE CheckListDb;
GO

-- Selecionar a base de dados
USE ChecklistDB;
GO

-- Criação da tabela Checklists
CREATE TABLE Checklists
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VeiculoId INT NOT NULL,
    SupervisorId INT NOT NULL,
    Observacoes NVARCHAR(MAX),
    Aprovado BIT NOT NULL,
    DataCriacao DATETIME2 DEFAULT GETUTCDATE() NOT NULL
);
GO

-- Criação da tabela ItemChecklists
CREATE TABLE ItemChecklists
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ChecklistId INT NOT NULL,
    Descricao NVARCHAR(MAX) NOT NULL,
    Conforme BIT NOT NULL,
    CONSTRAINT FK_ItemChecklist_Checklists FOREIGN KEY (ChecklistId) REFERENCES Checklists(Id) ON DELETE CASCADE
);
GO
