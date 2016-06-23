
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/23/2016 18:24:37
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

IF OBJECT_ID(N'[dbo].[FK_AcademicoContaAcademico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContaAcademicoSet] DROP CONSTRAINT [FK_AcademicoContaAcademico];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaWhislist_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaWhislist] DROP CONSTRAINT [FK_MediaWhislist_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaWhislist_Whislist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaWhislist] DROP CONSTRAINT [FK_MediaWhislist_Whislist];
GO
IF OBJECT_ID(N'[dbo].[FK_AcademicoWhislist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WhislistSet] DROP CONSTRAINT [FK_AcademicoWhislist];
GO
IF OBJECT_ID(N'[dbo].[FK_AcademicoMedia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet] DROP CONSTRAINT [FK_AcademicoMedia];
GO
IF OBJECT_ID(N'[dbo].[FK_TransacaoAcademico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AcademicoSet] DROP CONSTRAINT [FK_TransacaoAcademico];
GO
IF OBJECT_ID(N'[dbo].[FK_TransacaoMedia_Transacao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransacaoMedia] DROP CONSTRAINT [FK_TransacaoMedia_Transacao];
GO
IF OBJECT_ID(N'[dbo].[FK_TransacaoMedia_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransacaoMedia] DROP CONSTRAINT [FK_TransacaoMedia_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_Musica_inherits_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet_Musica] DROP CONSTRAINT [FK_Musica_inherits_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_Livro_inherits_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet_Livro] DROP CONSTRAINT [FK_Livro_inherits_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_Video_inherits_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet_Video] DROP CONSTRAINT [FK_Video_inherits_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_Autor_inherits_Academico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AcademicoSet_Autor] DROP CONSTRAINT [FK_Autor_inherits_Academico];
GO
IF OBJECT_ID(N'[dbo].[FK_Administrador_inherits_Autor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AcademicoSet_Administrador] DROP CONSTRAINT [FK_Administrador_inherits_Autor];
GO
IF OBJECT_ID(N'[dbo].[FK_Podcast_inherits_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet_Podcast] DROP CONSTRAINT [FK_Podcast_inherits_Media];
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
IF OBJECT_ID(N'[dbo].[MediaSet_Musica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet_Musica];
GO
IF OBJECT_ID(N'[dbo].[MediaSet_Livro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet_Livro];
GO
IF OBJECT_ID(N'[dbo].[MediaSet_Video]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet_Video];
GO
IF OBJECT_ID(N'[dbo].[AcademicoSet_Autor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AcademicoSet_Autor];
GO
IF OBJECT_ID(N'[dbo].[AcademicoSet_Administrador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AcademicoSet_Administrador];
GO
IF OBJECT_ID(N'[dbo].[MediaSet_Podcast]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet_Podcast];
GO
IF OBJECT_ID(N'[dbo].[MediaWhislist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaWhislist];
GO
IF OBJECT_ID(N'[dbo].[TransacaoMedia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransacaoMedia];
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
    [SegundoNome] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'MediaSet'
CREATE TABLE [dbo].[MediaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Publicado] bit  NOT NULL,
    [Preco] float  NOT NULL,
    [Categoria] nvarchar(max)  NOT NULL,
    [DataCriacao] datetime  NOT NULL,
    [Caminho] nvarchar(max)  NULL,
    [AcademicoId] int  NOT NULL,
    [Ativo] bit  NOT NULL,
    [Disponivel] bit  NULL
);
GO

-- Creating table 'TransacaoSet'
CREATE TABLE [dbo].[TransacaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valor] float  NOT NULL,
    [Ativo] bit  NOT NULL,
    [AcademicoId] int  NOT NULL
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
    [AcademicoId] int  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'ContaAcademicoSet'
CREATE TABLE [dbo].[ContaAcademicoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Credito] float  NOT NULL,
    [Ativo] bit  NOT NULL,
    [AcademicoContaAcademico_ContaAcademico_Id] int  NOT NULL
);
GO

-- Creating table 'MediaSet_Musica'
CREATE TABLE [dbo].[MediaSet_Musica] (
    [Duracao] float  NOT NULL,
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
    [Duracao] float  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AcademicoSet_Autor'
CREATE TABLE [dbo].[AcademicoSet_Autor] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'AcademicoSet_Administrador'
CREATE TABLE [dbo].[AcademicoSet_Administrador] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'MediaSet_Podcast'
CREATE TABLE [dbo].[MediaSet_Podcast] (
    [Duracao] float  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'MediaWhislist'
CREATE TABLE [dbo].[MediaWhislist] (
    [MediaDesejadas_Id] int  NOT NULL,
    [MediaWhislist_Media_Id] int  NOT NULL
);
GO

-- Creating table 'TransacaoMedia'
CREATE TABLE [dbo].[TransacaoMedia] (
    [TransacaoMedia_Media_Id] int  NOT NULL,
    [MediasTransacao_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'MediaSet_Musica'
ALTER TABLE [dbo].[MediaSet_Musica]
ADD CONSTRAINT [PK_MediaSet_Musica]
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

-- Creating primary key on [Id] in table 'AcademicoSet_Autor'
ALTER TABLE [dbo].[AcademicoSet_Autor]
ADD CONSTRAINT [PK_AcademicoSet_Autor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AcademicoSet_Administrador'
ALTER TABLE [dbo].[AcademicoSet_Administrador]
ADD CONSTRAINT [PK_AcademicoSet_Administrador]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MediaSet_Podcast'
ALTER TABLE [dbo].[MediaSet_Podcast]
ADD CONSTRAINT [PK_MediaSet_Podcast]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MediaDesejadas_Id], [MediaWhislist_Media_Id] in table 'MediaWhislist'
ALTER TABLE [dbo].[MediaWhislist]
ADD CONSTRAINT [PK_MediaWhislist]
    PRIMARY KEY CLUSTERED ([MediaDesejadas_Id], [MediaWhislist_Media_Id] ASC);
GO

-- Creating primary key on [TransacaoMedia_Media_Id], [MediasTransacao_Id] in table 'TransacaoMedia'
ALTER TABLE [dbo].[TransacaoMedia]
ADD CONSTRAINT [PK_TransacaoMedia]
    PRIMARY KEY CLUSTERED ([TransacaoMedia_Media_Id], [MediasTransacao_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [MediaDesejadas_Id] in table 'MediaWhislist'
ALTER TABLE [dbo].[MediaWhislist]
ADD CONSTRAINT [FK_MediaWhislist_Media]
    FOREIGN KEY ([MediaDesejadas_Id])
    REFERENCES [dbo].[MediaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MediaWhislist_Media_Id] in table 'MediaWhislist'
ALTER TABLE [dbo].[MediaWhislist]
ADD CONSTRAINT [FK_MediaWhislist_Whislist]
    FOREIGN KEY ([MediaWhislist_Media_Id])
    REFERENCES [dbo].[WhislistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaWhislist_Whislist'
CREATE INDEX [IX_FK_MediaWhislist_Whislist]
ON [dbo].[MediaWhislist]
    ([MediaWhislist_Media_Id]);
GO

-- Creating foreign key on [AcademicoId] in table 'WhislistSet'
ALTER TABLE [dbo].[WhislistSet]
ADD CONSTRAINT [FK_AcademicoWhislist]
    FOREIGN KEY ([AcademicoId])
    REFERENCES [dbo].[AcademicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcademicoWhislist'
CREATE INDEX [IX_FK_AcademicoWhislist]
ON [dbo].[WhislistSet]
    ([AcademicoId]);
GO

-- Creating foreign key on [AcademicoId] in table 'MediaSet'
ALTER TABLE [dbo].[MediaSet]
ADD CONSTRAINT [FK_AcademicoMedia]
    FOREIGN KEY ([AcademicoId])
    REFERENCES [dbo].[AcademicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcademicoMedia'
CREATE INDEX [IX_FK_AcademicoMedia]
ON [dbo].[MediaSet]
    ([AcademicoId]);
GO

-- Creating foreign key on [TransacaoMedia_Media_Id] in table 'TransacaoMedia'
ALTER TABLE [dbo].[TransacaoMedia]
ADD CONSTRAINT [FK_TransacaoMedia_Transacao]
    FOREIGN KEY ([TransacaoMedia_Media_Id])
    REFERENCES [dbo].[TransacaoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MediasTransacao_Id] in table 'TransacaoMedia'
ALTER TABLE [dbo].[TransacaoMedia]
ADD CONSTRAINT [FK_TransacaoMedia_Media]
    FOREIGN KEY ([MediasTransacao_Id])
    REFERENCES [dbo].[MediaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransacaoMedia_Media'
CREATE INDEX [IX_FK_TransacaoMedia_Media]
ON [dbo].[TransacaoMedia]
    ([MediasTransacao_Id]);
GO

-- Creating foreign key on [AcademicoId] in table 'TransacaoSet'
ALTER TABLE [dbo].[TransacaoSet]
ADD CONSTRAINT [FK_AcademicoTransacao]
    FOREIGN KEY ([AcademicoId])
    REFERENCES [dbo].[AcademicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcademicoTransacao'
CREATE INDEX [IX_FK_AcademicoTransacao]
ON [dbo].[TransacaoSet]
    ([AcademicoId]);
GO

-- Creating foreign key on [Id] in table 'MediaSet_Musica'
ALTER TABLE [dbo].[MediaSet_Musica]
ADD CONSTRAINT [FK_Musica_inherits_Media]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MediaSet]
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

-- Creating foreign key on [Id] in table 'AcademicoSet_Autor'
ALTER TABLE [dbo].[AcademicoSet_Autor]
ADD CONSTRAINT [FK_Autor_inherits_Academico]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AcademicoSet]
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

-- Creating foreign key on [Id] in table 'MediaSet_Podcast'
ALTER TABLE [dbo].[MediaSet_Podcast]
ADD CONSTRAINT [FK_Podcast_inherits_Media]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MediaSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------