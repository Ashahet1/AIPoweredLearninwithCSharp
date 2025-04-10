CREATE TABLE [dbo].[DistributedCache] (
    [Id]                         NVARCHAR (449)  NOT NULL,
    [Value]                      VARBINARY (MAX) NULL,
    [ExpiresAtTime]              DATETIME2 (7)   NULL,
    [SlidingExpirationInSeconds] BIGINT          NULL,
    [AbsoluteExpiration]         DATETIME2 (7)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_DistributedCache_ExpiresAtTime]
    ON [dbo].[DistributedCache]([ExpiresAtTime] ASC);

