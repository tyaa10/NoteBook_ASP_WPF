CREATE TABLE [dbo].[States] (
	[id]   INT          IDENTITY (1, 1) NOT NULL,
	[name] VARCHAR (25) NOT NULL,
	PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[AnOrders] (
	[id]            INT           IDENTITY (1, 1) NOT NULL,
	[customer_name] VARCHAR (25)  NOT NULL,
	[description]   VARCHAR (255) NOT NULL,
	[created_at]    DATE          NOT NULL,
	[state_id]      INT           NULL,
	PRIMARY KEY CLUSTERED ([id] ASC),
	FOREIGN KEY ([state_id]) REFERENCES [dbo].[States] ([id])
);

CREATE TABLE [dbo].[UserTypes]
(
	[id] INT IDENTITY PRIMARY KEY
	, [name] VARCHAR(25) NOT NULL
);

CREATE TABLE [dbo].[Users]
(
	[id] INT IDENTITY PRIMARY KEY
	, [login] VARCHAR(25) NOT NULL
	, [password] VARCHAR(255) NOT NULL
	, [user_type_id] INT REFERENCES [UserTypes]([id]) NOT NULL
)