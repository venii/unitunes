
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/15/2016 21:06:12
-- Generated from EDMX file: C:\Users\Vinicius\Desktop\Unitunes_final\Unitunes\Unitunes\Models\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AcademicoMedia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet] DROP CONSTRAINT [FK_AcademicoMedia];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaTransacao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet] DROP CONSTRAINT [FK_MediaTransacao];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaAutor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet] DROP CONSTRAINT [FK_MediaAutor];
GO
IF OBJECT_ID(N'[dbo].[FK_MusicaAlbum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet_Musica] DROP CONSTRAINT [FK_MusicaAlbum];
GO
IF OBJECT_ID(N'[dbo].[FK_AlbumAutor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AcademicoSet_Autor] DROP CONSTRAINT [FK_AlbumAutor];
GO
IF OBJECT_ID(N'[dbo].[FK_TransacaoAdministrador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransacaoSet] DROP CONSTRAINT [FK_TransacaoAdministrador];
GO
IF OBJECT_ID(N'[dbo].[FK_TransacaoAutor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransacaoSet] DROP CONSTRAINT [FK_TransacaoAutor];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaWhislist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet] DROP CONSTRAINT [FK_MediaWhislist];
GO
IF OBJECT_ID(N'[dbo].[FK_AcademicoContaAcademico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AcademicoSet] DROP CONSTRAINT [FK_AcademicoContaAcademico];
GO
IF OBJECT_ID(N'[dbo].[FK_AcademicoWhislist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WhislistSet] DROP CONSTRAINT [FK_AcademicoWhislist];
GO
IF OBJECT_ID(N'[dbo].[FK_Autor_inherits_Academico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AcademicoSet_Autor] DROP CONSTRAINT [FK_Autor_inherits_Academico];
GO
IF OBJECT_ID(N'[dbo].[FK_Musica_inherits_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet_Musica] DROP CONSTRAINT [FK_Musica_inherits_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_Administrador_inherits_Autor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AcademicoSet_Administrador] DROP CONSTRAINT [FK_Administrador_inherits_Autor];
GO
IF OBJECT_ID(N'[dbo].[FK_Livro_inherits_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet_Livro] DROP CONSTRAINT [FK_Livro_inherits_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_Video_inherits_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet_Video] DROP CONSTRAINT [FK_Video_inherits_Media];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AcademicoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AcademicoSet];
GO
IF OBJECT_ID(N'[dbo].[MediaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet];
GO
IF OBJECT_ID(N'[dbo].[TransacaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransacaoSet];
GO
IF OBJECT_ID(N'[dbo].[AlbumSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlbumSet];
GO
IF OBJECT_ID(N'[dbo].[WhislistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WhislistSet];
GO
IF OBJECT_ID(N'[dbo].[ContaAcademicoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContaAcademicoSet];
GO
IF OBJECT_ID(N'[dbo].[AcademicoSet_Autor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AcademicoSet_Autor];
GO
IF OBJECT_ID(N'[dbo].[MediaSet_Musica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet_Musica];
GO
IF OBJECT_ID(N'[dbo].[AcademicoSet_Administrador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AcademicoSet_Administrador];
GO
IF OBJECT_ID(N'[dbo].[MediaSet_Livro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet_Livro];
GO
IF OBJECT_ID(N'[dbo].[MediaSet_Video]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet_Video];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AcademicoSet'
CREATE TABLE [dbo].[AcademicoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [PrimeiroNome] nvarchar(max)  NOT NULL,
    [SegundoNome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MediaSet'
CREATE TABLE [dbo].[MediaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Publicado] nvarchar(max)  NOT NULL,
    [Preco] decimal(18,0)  NOT NULL,
    [Categoria] nvarchar(max)  NOT NULL,
    [DataCriacao] datetime  NOT NULL,
    [Academico_Id] int  NOT NULL,
    [Transacao_Id] int  NOT NULL,
    [Autor_Id] int  NOT NULL,
    [Whislist_Id] int  NOT NULL
);
GO

-- Creating table 'TransacaoSet'
CREATE TABLE [dbo].[TransacaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [valor] float  NOT NULL,
    [Administrador_Id] int  NOT NULL,
    [Autor_Id] int  NOT NULL
);
GO

-- Creating table 'AlbumSet'
CREATE TABLE [dbo].[AlbumSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [DataCriacao] datetime  NOT NULL
);
GO

-- Creating table 'WhislistSet'
CREATE TABLE [dbo].[WhislistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [AcademicoWhislist_Whislist_Id] int  NULL
);
GO

-- Creating table 'ContaAcademicoSet'
CREATE TABLE [dbo].[ContaAcademicoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Credito] float  NOT NULL,
    [AcademicoContaAcademico_ContaAcademico_Id] int  NOT NULL
);
GO

-- Creating table 'AcademicoSet_Autor'
CREATE TABLE [dbo].[AcademicoSet_Autor] (
    [Id] int  NOT NULL,
    [Album_Id] int  NOT NULL
);
GO

-- Creating table 'MediaSet_Musica'
CREATE TABLE [dbo].[MediaSet_Musica] (
    [Duracao] float  NOT NULL,
    [Id] int  NOT NULL,
    [Album_Id] int  NOT NULL
);
GO

-- Creating table 'AcademicoSet_Administrador'
CREATE TABLE [dbo].[AcademicoSet_Administrador] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'MediaSet_Livro'
CREATE TABLE [dbo].[MediaSet_Livro] (
    [NumeroPaginas] smallint  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'MediaSet_Video'
CREATE TABLE [dbo].[MediaSet_Video] (
    [Duracao] decimal(18,0)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AcademicoSet'
ALTER TABLE [dbo].[AcademicoSet]
ADD CONSTRAINT [PK_AcademicoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MediaSet'
ALTER TABLE [dbo].[MediaSet]
ADD CONSTRAINT [PK_MediaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransacaoSet'
ALTER TABLE [dbo].[TransacaoSet]
ADD CONSTRAINT [PK_TransacaoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AlbumSet'
ALTER TABLE [dbo].[AlbumSet]
ADD CONSTRAINT [PK_AlbumSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WhislistSet'
ALTER TABLE [dbo].[WhislistSet]
ADD CONSTRAINT [PK_WhislistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContaAcademicoSet'
ALTER TABLE [dbo].[ContaAcademicoSet]
ADD CONSTRAINT [PK_ContaAcademicoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AcademicoSet_Autor'
ALTER TABLE [dbo].[AcademicoSet_Autor]
ADD CONSTRAINT [PK_AcademicoSet_Autor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MediaSet_Musica'
ALTER TABLE [dbo].[MediaSet_Musica]
ADD CONSTRAINT [PK_MediaSet_Musica]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AcademicoSet_Administrador'
ALTER TABLE [dbo].[AcademicoSet_Administrador]
ADD CONSTRAINT [PK_AcademicoSet_Administrador]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MediaSet_Livro'
ALTER TABLE [dbo].[MediaSet_Livro]
ADD CONSTRAINT [PK_MediaSet_Livro]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MediaSet_Video'
ALTER TABLE [dbo].[MediaSet_Video]
ADD CONSTRAINT [PK_MediaSet_Video]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Academico_Id] in table 'MediaSet'
ALTER TABLE [dbo].[MediaSet]
ADD CONSTRAINT [FK_AcademicoMedia]
    FOREIGN KEY ([Academico_Id])
    REFERENCES [dbo].[AcademicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcademicoMedia'
CREATE INDEX [IX_FK_AcademicoMedia]
ON [dbo].[MediaSet]
    ([Academico_Id]);
GO

-- Creating foreign key on [Transacao_Id] in table 'MediaSet'
ALTER TABLE [dbo].[MediaSet]
ADD CONSTRAINT [FK_MediaTransacao]
    FOREIGN KEY ([Transacao_Id])
    REFERENCES [dbo].[TransacaoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaTransacao'
CREATE INDEX [IX_FK_MediaTransacao]
ON [dbo].[MediaSet]
    ([Transacao_Id]);
GO

-- Creating foreign key on [Autor_Id] in table 'MediaSet'
ALTER TABLE [dbo].[MediaSet]
ADD CONSTRAINT [FK_MediaAutor]
    FOREIGN KEY ([Autor_Id])
    REFERENCES [dbo].[AcademicoSet_Autor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaAutor'
CREATE INDEX [IX_FK_MediaAutor]
ON [dbo].[MediaSet]
    ([Autor_Id]);
GO

-- Creating foreign key on [Album_Id] in table 'MediaSet_Musica'
ALTER TABLE [dbo].[MediaSet_Musica]
ADD CONSTRAINT [FK_MusicaAlbum]
    FOREIGN KEY ([Album_Id])
    REFERENCES [dbo].[AlbumSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MusicaAlbum'
CREATE INDEX [IX_FK_MusicaAlbum]
ON [dbo].[MediaSet_Musica]
    ([Album_Id]);
GO

-- Creating foreign key on [Album_Id] in table 'AcademicoSet_Autor'
ALTER TABLE [dbo].[AcademicoSet_Autor]
ADD CONSTRAINT [FK_AlbumAutor]
    FOREIGN KEY ([Album_Id])
    REFERENCES [dbo].[AlbumSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlbumAutor'
CREATE INDEX [IX_FK_AlbumAutor]
ON [dbo].[AcademicoSet_Autor]
    ([Album_Id]);
GO

-- Creating foreign key on [Administrador_Id] in table 'TransacaoSet'
ALTER TABLE [dbo].[TransacaoSet]
ADD CONSTRAINT [FK_TransacaoAdministrador]
    FOREIGN KEY ([Administrador_Id])
    REFERENCES [dbo].[AcademicoSet_Administrador]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransacaoAdministrador'
CREATE INDEX [IX_FK_TransacaoAdministrador]
ON [dbo].[TransacaoSet]
    ([Administrador_Id]);
GO

-- Creating foreign key on [Autor_Id] in table 'TransacaoSet'
ALTER TABLE [dbo].[TransacaoSet]
ADD CONSTRAINT [FK_TransacaoAutor]
    FOREIGN KEY ([Autor_Id])
    REFERENCES [dbo].[AcademicoSet_Autor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransacaoAutor'
CREATE INDEX [IX_FK_TransacaoAutor]
ON [dbo].[TransacaoSet]
    ([Autor_Id]);
GO

-- Creating foreign key on [Whislist_Id] in table 'MediaSet'
ALTER TABLE [dbo].[MediaSet]
ADD CONSTRAINT [FK_MediaWhislist]
    FOREIGN KEY ([Whislist_Id])
    REFERENCES [dbo].[WhislistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaWhislist'
CREATE INDEX [IX_FK_MediaWhislist]
ON [dbo].[MediaSet]
    ([Whislist_Id]);
GO

-- Creating foreign key on [AcademicoWhislist_Whislist_Id] in table 'WhislistSet'
ALTER TABLE [dbo].[WhislistSet]
ADD CONSTRAINT [FK_AcademicoWhislist]
    FOREIGN KEY ([AcademicoWhislist_Whislist_Id])
    REFERENCES [dbo].[AcademicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcademicoWhislist'
CREATE INDEX [IX_FK_AcademicoWhislist]
ON [dbo].[WhislistSet]
    ([AcademicoWhislist_Whislist_Id]);
GO

-- Creating foreign key on [AcademicoContaAcademico_ContaAcademico_Id] in table 'ContaAcademicoSet'
ALTER TABLE [dbo].[ContaAcademicoSet]
ADD CONSTRAINT [FK_AcademicoContaAcademico]
    FOREIGN KEY ([AcademicoContaAcademico_ContaAcademico_Id])
    REFERENCES [dbo].[AcademicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcademicoContaAcademico'
CREATE INDEX [IX_FK_AcademicoContaAcademico]
ON [dbo].[ContaAcademicoSet]
    ([AcademicoContaAcademico_ContaAcademico_Id]);
GO

-- Creating foreign key on [Id] in table 'AcademicoSet_Autor'
ALTER TABLE [dbo].[AcademicoSet_Autor]
ADD CONSTRAINT [FK_Autor_inherits_Academico]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AcademicoSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'MediaSet_Musica'
ALTER TABLE [dbo].[MediaSet_Musica]
ADD CONSTRAINT [FK_Musica_inherits_Media]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MediaSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AcademicoSet_Administrador'
ALTER TABLE [dbo].[AcademicoSet_Administrador]
ADD CONSTRAINT [FK_Administrador_inherits_Autor]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AcademicoSet_Autor]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'MediaSet_Livro'
ALTER TABLE [dbo].[MediaSet_Livro]
ADD CONSTRAINT [FK_Livro_inherits_Media]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MediaSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'MediaSet_Video'
ALTER TABLE [dbo].[MediaSet_Video]
ADD CONSTRAINT [FK_Video_inherits_Media]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MediaSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------