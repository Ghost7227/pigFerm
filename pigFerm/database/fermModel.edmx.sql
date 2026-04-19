
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/15/2026 08:43:33
-- Generated from EDMX file: E:\курсовая 3 курс\pigFerm\pigFerm\database\fermModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ferm];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__AnimalGro__idEmp__19DFD96B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnimalGroups] DROP CONSTRAINT [FK__AnimalGro__idEmp__19DFD96B];
GO
IF OBJECT_ID(N'[dbo].[FK__AnimalGro__idRoo__18EBB532]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnimalGroups] DROP CONSTRAINT [FK__AnimalGro__idRoo__18EBB532];
GO
IF OBJECT_ID(N'[dbo].[FK__AnimalGro__idTyp__17F790F9]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnimalGroups] DROP CONSTRAINT [FK__AnimalGro__idTyp__17F790F9];
GO
IF OBJECT_ID(N'[dbo].[FK__Animals__group_i__22751F6C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals] DROP CONSTRAINT [FK__Animals__group_i__22751F6C];
GO
IF OBJECT_ID(N'[dbo].[FK__Animals__breed__1F98B2C1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals] DROP CONSTRAINT [FK__Animals__breed__1F98B2C1];
GO
IF OBJECT_ID(N'[dbo].[FK__Animals__father___2180FB33]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals] DROP CONSTRAINT [FK__Animals__father___2180FB33];
GO
IF OBJECT_ID(N'[dbo].[FK__Animals__mother___208CD6FA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals] DROP CONSTRAINT [FK__Animals__mother___208CD6FA];
GO
IF OBJECT_ID(N'[dbo].[FK__shipments__idCou__282DF8C2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[shipments] DROP CONSTRAINT [FK__shipments__idCou__282DF8C2];
GO
IF OBJECT_ID(N'[dbo].[FK__posts__idDeparta__0B91BA14]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[posts] DROP CONSTRAINT [FK__posts__idDeparta__0B91BA14];
GO
IF OBJECT_ID(N'[dbo].[FK__employees__idpos__10566F31]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[employees] DROP CONSTRAINT [FK__employees__idpos__10566F31];
GO
IF OBJECT_ID(N'[dbo].[FK__EventEmpl__emplo__43D61337]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventEmployees] DROP CONSTRAINT [FK__EventEmpl__emplo__43D61337];
GO
IF OBJECT_ID(N'[dbo].[FK__EventEmpl__event__42E1EEFE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventEmployees] DROP CONSTRAINT [FK__EventEmpl__event__42E1EEFE];
GO
IF OBJECT_ID(N'[dbo].[FK__events__idType__31B762FC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[events] DROP CONSTRAINT [FK__events__idType__31B762FC];
GO
IF OBJECT_ID(N'[dbo].[FK__products__idEven__37703C52]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK__products__idEven__37703C52];
GO
IF OBJECT_ID(N'[dbo].[FK__productSh__idShi__3B40CD36]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productShipments] DROP CONSTRAINT [FK__productSh__idShi__3B40CD36];
GO
IF OBJECT_ID(N'[dbo].[FK__products__idType__3587F3E0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK__products__idType__3587F3E0];
GO
IF OBJECT_ID(N'[dbo].[FK__productSh__idPro__3A4CA8FD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productShipments] DROP CONSTRAINT [FK__productSh__idPro__3A4CA8FD];
GO
IF OBJECT_ID(N'[dbo].[FK__rooms__typeRoom__151B244E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[rooms] DROP CONSTRAINT [FK__rooms__typeRoom__151B244E];
GO
IF OBJECT_ID(N'[dbo].[FK_EventAnimal_Animals]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventAnimal] DROP CONSTRAINT [FK_EventAnimal_Animals];
GO
IF OBJECT_ID(N'[dbo].[FK_EventAnimal_events]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventAnimal] DROP CONSTRAINT [FK_EventAnimal_events];
GO
IF OBJECT_ID(N'[dbo].[FK__productSh__idShi__503BEA1C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productShipments] DROP CONSTRAINT [FK__productSh__idShi__503BEA1C];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AnimalGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnimalGroups];
GO
IF OBJECT_ID(N'[dbo].[Animals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Animals];
GO
IF OBJECT_ID(N'[dbo].[breeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[breeds];
GO
IF OBJECT_ID(N'[dbo].[counterparties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[counterparties];
GO
IF OBJECT_ID(N'[dbo].[departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[departments];
GO
IF OBJECT_ID(N'[dbo].[employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[employees];
GO
IF OBJECT_ID(N'[dbo].[EventEmployees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventEmployees];
GO
IF OBJECT_ID(N'[dbo].[events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[events];
GO
IF OBJECT_ID(N'[dbo].[EventTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventTypes];
GO
IF OBJECT_ID(N'[dbo].[groupTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[groupTypes];
GO
IF OBJECT_ID(N'[dbo].[posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[posts];
GO
IF OBJECT_ID(N'[dbo].[products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[products];
GO
IF OBJECT_ID(N'[dbo].[productShipments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productShipments];
GO
IF OBJECT_ID(N'[dbo].[productTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productTypes];
GO
IF OBJECT_ID(N'[dbo].[rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rooms];
GO
IF OBJECT_ID(N'[dbo].[roomTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[roomTypes];
GO
IF OBJECT_ID(N'[dbo].[shipments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[shipments];
GO
IF OBJECT_ID(N'[dbo].[EventAnimal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventAnimal];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AnimalGroups'
CREATE TABLE [dbo].[AnimalGroups] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idType] int  NOT NULL,
    [idRoom] int  NOT NULL,
    [idEmployee] int  NOT NULL
);
GO

-- Creating table 'Animals'
CREATE TABLE [dbo].[Animals] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ear_tag] nvarchar(50)  NOT NULL,
    [name] nvarchar(100)  NULL,
    [gender] nchar(1)  NOT NULL,
    [birth_date] datetime  NOT NULL,
    [breed] int  NULL,
    [arrival_date] datetime  NULL,
    [origin] nvarchar(255)  NULL,
    [mother_id] int  NULL,
    [father_id] int  NULL,
    [group_id] int  NULL,
    [status] nvarchar(50)  NULL
);
GO

-- Creating table 'breeds'
CREATE TABLE [dbo].[breeds] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nameBreed] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'counterparties'
CREATE TABLE [dbo].[counterparties] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nameCounterparties] nvarchar(100)  NOT NULL,
    [adres] nvarchar(100)  NOT NULL,
    [description] nvarchar(max)  NULL,
    [isRegular] bit  NOT NULL,
    [category] nvarchar(20)  NULL
);
GO

-- Creating table 'departments'
CREATE TABLE [dbo].[departments] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nameDepartment] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'employees'
CREATE TABLE [dbo].[employees] (
    [id] int IDENTITY(1,1) NOT NULL,
    [firstName] nvarchar(100)  NOT NULL,
    [midleName] nvarchar(100)  NULL,
    [lastName] nvarchar(100)  NOT NULL,
    [gender] char(1)  NULL,
    [birthday] datetime  NOT NULL,
    [pasport] nvarchar(10)  NOT NULL,
    [snils] nvarchar(14)  NOT NULL,
    [inn] nvarchar(12)  NOT NULL,
    [phone] nvarchar(11)  NOT NULL,
    [email] nvarchar(100)  NOT NULL,
    [idpost] int  NOT NULL
);
GO

-- Creating table 'EventEmployees'
CREATE TABLE [dbo].[EventEmployees] (
    [eventId] int  NOT NULL,
    [employeeId] int  NOT NULL,
    [description] nvarchar(255)  NULL
);
GO

-- Creating table 'events'
CREATE TABLE [dbo].[events] (
    [id] int IDENTITY(1,1) NOT NULL,
    [dateTime] datetime  NOT NULL,
    [idType] int  NOT NULL,
    [descriiption] nvarchar(max)  NULL
);
GO

-- Creating table 'EventTypes'
CREATE TABLE [dbo].[EventTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nameEvent] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'groupTypes'
CREATE TABLE [dbo].[groupTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nameGroup] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'posts'
CREATE TABLE [dbo].[posts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [namePost] nvarchar(100)  NOT NULL,
    [salary] decimal(19,4)  NOT NULL,
    [idDepartament] int  NOT NULL
);
GO

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [id] int IDENTITY(1,1) NOT NULL,
    [quantity] int  NOT NULL,
    [descriiption] nvarchar(max)  NOT NULL,
    [idType] int  NOT NULL,
    [prodauctionDate] datetime  NOT NULL,
    [expirationDate] datetime  NOT NULL,
    [idEvent] int  NOT NULL
);
GO

-- Creating table 'productShipments'
CREATE TABLE [dbo].[productShipments] (
    [idProduct] int  NOT NULL,
    [idShipment] int  NOT NULL,
    [quantity] int  NOT NULL
);
GO

-- Creating table 'productTypes'
CREATE TABLE [dbo].[productTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nameTypeProduct] nvarchar(100)  NOT NULL,
    [unit] nvarchar(100)  NOT NULL,
    [cost] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'rooms'
CREATE TABLE [dbo].[rooms] (
    [id] int IDENTITY(1,1) NOT NULL,
    [adres] nvarchar(100)  NOT NULL,
    [capacity] int  NOT NULL,
    [currentCount] int  NOT NULL,
    [locationNotes] nvarchar(255)  NULL,
    [typeRoom] int  NOT NULL
);
GO

-- Creating table 'roomTypes'
CREATE TABLE [dbo].[roomTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nameRoomTtpes] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'shipments'
CREATE TABLE [dbo].[shipments] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idCounterapies] int  NOT NULL,
    [date] datetime  NOT NULL,
    [sum] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'EventAnimal'
CREATE TABLE [dbo].[EventAnimal] (
    [Animals_id] int  NOT NULL,
    [events_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'AnimalGroups'
ALTER TABLE [dbo].[AnimalGroups]
ADD CONSTRAINT [PK_AnimalGroups]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [PK_Animals]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'breeds'
ALTER TABLE [dbo].[breeds]
ADD CONSTRAINT [PK_breeds]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'counterparties'
ALTER TABLE [dbo].[counterparties]
ADD CONSTRAINT [PK_counterparties]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'departments'
ALTER TABLE [dbo].[departments]
ADD CONSTRAINT [PK_departments]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'employees'
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [PK_employees]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [eventId], [employeeId] in table 'EventEmployees'
ALTER TABLE [dbo].[EventEmployees]
ADD CONSTRAINT [PK_EventEmployees]
    PRIMARY KEY CLUSTERED ([eventId], [employeeId] ASC);
GO

-- Creating primary key on [id] in table 'events'
ALTER TABLE [dbo].[events]
ADD CONSTRAINT [PK_events]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'EventTypes'
ALTER TABLE [dbo].[EventTypes]
ADD CONSTRAINT [PK_EventTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'groupTypes'
ALTER TABLE [dbo].[groupTypes]
ADD CONSTRAINT [PK_groupTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'posts'
ALTER TABLE [dbo].[posts]
ADD CONSTRAINT [PK_posts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [idProduct], [idShipment] in table 'productShipments'
ALTER TABLE [dbo].[productShipments]
ADD CONSTRAINT [PK_productShipments]
    PRIMARY KEY CLUSTERED ([idProduct], [idShipment] ASC);
GO

-- Creating primary key on [id] in table 'productTypes'
ALTER TABLE [dbo].[productTypes]
ADD CONSTRAINT [PK_productTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'rooms'
ALTER TABLE [dbo].[rooms]
ADD CONSTRAINT [PK_rooms]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'roomTypes'
ALTER TABLE [dbo].[roomTypes]
ADD CONSTRAINT [PK_roomTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'shipments'
ALTER TABLE [dbo].[shipments]
ADD CONSTRAINT [PK_shipments]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Animals_id], [events_id] in table 'EventAnimal'
ALTER TABLE [dbo].[EventAnimal]
ADD CONSTRAINT [PK_EventAnimal]
    PRIMARY KEY CLUSTERED ([Animals_id], [events_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idEmployee] in table 'AnimalGroups'
ALTER TABLE [dbo].[AnimalGroups]
ADD CONSTRAINT [FK__AnimalGro__idEmp__19DFD96B]
    FOREIGN KEY ([idEmployee])
    REFERENCES [dbo].[employees]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__AnimalGro__idEmp__19DFD96B'
CREATE INDEX [IX_FK__AnimalGro__idEmp__19DFD96B]
ON [dbo].[AnimalGroups]
    ([idEmployee]);
GO

-- Creating foreign key on [idRoom] in table 'AnimalGroups'
ALTER TABLE [dbo].[AnimalGroups]
ADD CONSTRAINT [FK__AnimalGro__idRoo__18EBB532]
    FOREIGN KEY ([idRoom])
    REFERENCES [dbo].[rooms]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__AnimalGro__idRoo__18EBB532'
CREATE INDEX [IX_FK__AnimalGro__idRoo__18EBB532]
ON [dbo].[AnimalGroups]
    ([idRoom]);
GO

-- Creating foreign key on [idType] in table 'AnimalGroups'
ALTER TABLE [dbo].[AnimalGroups]
ADD CONSTRAINT [FK__AnimalGro__idTyp__17F790F9]
    FOREIGN KEY ([idType])
    REFERENCES [dbo].[groupTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__AnimalGro__idTyp__17F790F9'
CREATE INDEX [IX_FK__AnimalGro__idTyp__17F790F9]
ON [dbo].[AnimalGroups]
    ([idType]);
GO

-- Creating foreign key on [group_id] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [FK__Animals__group_i__22751F6C]
    FOREIGN KEY ([group_id])
    REFERENCES [dbo].[AnimalGroups]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Animals__group_i__22751F6C'
CREATE INDEX [IX_FK__Animals__group_i__22751F6C]
ON [dbo].[Animals]
    ([group_id]);
GO

-- Creating foreign key on [breed] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [FK__Animals__breed__1F98B2C1]
    FOREIGN KEY ([breed])
    REFERENCES [dbo].[breeds]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Animals__breed__1F98B2C1'
CREATE INDEX [IX_FK__Animals__breed__1F98B2C1]
ON [dbo].[Animals]
    ([breed]);
GO

-- Creating foreign key on [father_id] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [FK__Animals__father___2180FB33]
    FOREIGN KEY ([father_id])
    REFERENCES [dbo].[Animals]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Animals__father___2180FB33'
CREATE INDEX [IX_FK__Animals__father___2180FB33]
ON [dbo].[Animals]
    ([father_id]);
GO

-- Creating foreign key on [mother_id] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [FK__Animals__mother___208CD6FA]
    FOREIGN KEY ([mother_id])
    REFERENCES [dbo].[Animals]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Animals__mother___208CD6FA'
CREATE INDEX [IX_FK__Animals__mother___208CD6FA]
ON [dbo].[Animals]
    ([mother_id]);
GO

-- Creating foreign key on [idCounterapies] in table 'shipments'
ALTER TABLE [dbo].[shipments]
ADD CONSTRAINT [FK__shipments__idCou__282DF8C2]
    FOREIGN KEY ([idCounterapies])
    REFERENCES [dbo].[counterparties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__shipments__idCou__282DF8C2'
CREATE INDEX [IX_FK__shipments__idCou__282DF8C2]
ON [dbo].[shipments]
    ([idCounterapies]);
GO

-- Creating foreign key on [idDepartament] in table 'posts'
ALTER TABLE [dbo].[posts]
ADD CONSTRAINT [FK__posts__idDeparta__0B91BA14]
    FOREIGN KEY ([idDepartament])
    REFERENCES [dbo].[departments]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__posts__idDeparta__0B91BA14'
CREATE INDEX [IX_FK__posts__idDeparta__0B91BA14]
ON [dbo].[posts]
    ([idDepartament]);
GO

-- Creating foreign key on [idpost] in table 'employees'
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [FK__employees__idpos__10566F31]
    FOREIGN KEY ([idpost])
    REFERENCES [dbo].[posts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__employees__idpos__10566F31'
CREATE INDEX [IX_FK__employees__idpos__10566F31]
ON [dbo].[employees]
    ([idpost]);
GO

-- Creating foreign key on [employeeId] in table 'EventEmployees'
ALTER TABLE [dbo].[EventEmployees]
ADD CONSTRAINT [FK__EventEmpl__emplo__43D61337]
    FOREIGN KEY ([employeeId])
    REFERENCES [dbo].[employees]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__EventEmpl__emplo__43D61337'
CREATE INDEX [IX_FK__EventEmpl__emplo__43D61337]
ON [dbo].[EventEmployees]
    ([employeeId]);
GO

-- Creating foreign key on [eventId] in table 'EventEmployees'
ALTER TABLE [dbo].[EventEmployees]
ADD CONSTRAINT [FK__EventEmpl__event__42E1EEFE]
    FOREIGN KEY ([eventId])
    REFERENCES [dbo].[events]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idType] in table 'events'
ALTER TABLE [dbo].[events]
ADD CONSTRAINT [FK__events__idType__31B762FC]
    FOREIGN KEY ([idType])
    REFERENCES [dbo].[EventTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__events__idType__31B762FC'
CREATE INDEX [IX_FK__events__idType__31B762FC]
ON [dbo].[events]
    ([idType]);
GO

-- Creating foreign key on [idEvent] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK__products__idEven__37703C52]
    FOREIGN KEY ([idEvent])
    REFERENCES [dbo].[events]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__products__idEven__37703C52'
CREATE INDEX [IX_FK__products__idEven__37703C52]
ON [dbo].[products]
    ([idEvent]);
GO

-- Creating foreign key on [idShipment] in table 'productShipments'
ALTER TABLE [dbo].[productShipments]
ADD CONSTRAINT [FK__productSh__idShi__3B40CD36]
    FOREIGN KEY ([idShipment])
    REFERENCES [dbo].[events]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__productSh__idShi__3B40CD36'
CREATE INDEX [IX_FK__productSh__idShi__3B40CD36]
ON [dbo].[productShipments]
    ([idShipment]);
GO

-- Creating foreign key on [idType] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK__products__idType__3587F3E0]
    FOREIGN KEY ([idType])
    REFERENCES [dbo].[productTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__products__idType__3587F3E0'
CREATE INDEX [IX_FK__products__idType__3587F3E0]
ON [dbo].[products]
    ([idType]);
GO

-- Creating foreign key on [idProduct] in table 'productShipments'
ALTER TABLE [dbo].[productShipments]
ADD CONSTRAINT [FK__productSh__idPro__3A4CA8FD]
    FOREIGN KEY ([idProduct])
    REFERENCES [dbo].[products]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [typeRoom] in table 'rooms'
ALTER TABLE [dbo].[rooms]
ADD CONSTRAINT [FK__rooms__typeRoom__151B244E]
    FOREIGN KEY ([typeRoom])
    REFERENCES [dbo].[roomTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__rooms__typeRoom__151B244E'
CREATE INDEX [IX_FK__rooms__typeRoom__151B244E]
ON [dbo].[rooms]
    ([typeRoom]);
GO

-- Creating foreign key on [Animals_id] in table 'EventAnimal'
ALTER TABLE [dbo].[EventAnimal]
ADD CONSTRAINT [FK_EventAnimal_Animals]
    FOREIGN KEY ([Animals_id])
    REFERENCES [dbo].[Animals]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [events_id] in table 'EventAnimal'
ALTER TABLE [dbo].[EventAnimal]
ADD CONSTRAINT [FK_EventAnimal_events]
    FOREIGN KEY ([events_id])
    REFERENCES [dbo].[events]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventAnimal_events'
CREATE INDEX [IX_FK_EventAnimal_events]
ON [dbo].[EventAnimal]
    ([events_id]);
GO

-- Creating foreign key on [idShipment] in table 'productShipments'
ALTER TABLE [dbo].[productShipments]
ADD CONSTRAINT [FK__productSh__idShi__503BEA1C]
    FOREIGN KEY ([idShipment])
    REFERENCES [dbo].[shipments]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__productSh__idShi__503BEA1C'
CREATE INDEX [IX_FK__productSh__idShi__503BEA1C]
ON [dbo].[productShipments]
    ([idShipment]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------