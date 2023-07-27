CREATE TABLE [__EFMigrationsHistory] (
[MigrationId] nvarchar(150) NOT NULL,
[ProductVersion] nvarchar(32) NOT NULL,
CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
);

CREATE TABLE [DnD5ePlayerCharacter] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Race] nvarchar(max) NOT NULL,
    [Class] nvarchar(max) NOT NULL,
    [Level] int NOT NULL,
    [charStrength] int NOT NULL,
    [charDexterity] int NOT NULL,
    [charConstitution] int NOT NULL,
    [charIntelligence] int NOT NULL,
    [charWisdom] int NOT NULL,
    [charCharisma] int NOT NULL,
    [HitPoints] int NOT NULL,
    [Background] nvarchar(max) NOT NULL,
    [Alignment] nvarchar(max) NOT NULL,
    [Player] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_DnD5ePlayerCharacter] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230724165033_InitialSetup', N'7.0.9');
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230725181954_Weapons', N'7.0.9');
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230725184153_AddedItems', N'7.0.9');
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230725192536_itemsnulladd', N'7.0.9');
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230725225451_DebugTest', N'7.0.9');
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230726165313_Spells', N'7.0.9');
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230727002230_SubmitStage', N'7.0.9');






CREATE TABLE [DnD5eWeapon] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [WeightInPounds] int NOT NULL,
    [CostInGoldPieces] int NOT NULL,
    [WeaponType] int NOT NULL,
    [DamageDice] int NOT NULL,
    [NumberOfDice] int NOT NULL,
    [BonusDamage] int NOT NULL,
    [IsMagical] bit NOT NULL,
    CONSTRAINT [PK_DnD5eWeapon] PRIMARY KEY ([Id])
);

CREATE TABLE [DnD5ePlayerItem] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [WeightInPounds] int NOT NULL,
    [CostInGoldPieces] int NOT NULL,
    [Notes] nvarchar(max) NULL,
    CONSTRAINT [PK_DnD5ePlayerItem] PRIMARY KEY ([Id])
);

CREATE TABLE [Spell] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [SpellLevel] int NOT NULL,
    [CastingTime] nvarchar(max) NOT NULL,
    [School] nvarchar(max) NOT NULL,
    [DamageDice] int NULL,
    [NumberOfDice] int NULL,
    [Bonus] nvarchar(max) NULL,
    [Range] nvarchar(max) NOT NULL,
    [Duration] nvarchar(max) NOT NULL,
    [Save] nvarchar(max) NOT NULL,
    [Effect] nvarchar(max) NOT NULL,
    [Components] nvarchar(max) NULL,
    [IsConcentration] bit NOT NULL,
    [IsRitual] bit NOT NULL,
    CONSTRAINT [PK_Spell] PRIMARY KEY ([Id])
);


SET IDENTITY_INSERT [dbo].[DnD5ePlayerCharacter] ON
INSERT INTO [dbo].[DnD5ePlayerCharacter] ([Id], [Name], [Race], [Class], [Level], [charStrength], [charDexterity], [charConstitution], [charIntelligence], [charWisdom], [charCharisma], [HitPoints], [Background], [Alignment], [Player]) VALUES (1, N'ASNMDO', N'Dragonborn', N'Barbarian', 1, 5, 5, 5, 5, 5, 45, 54, N'sdf', N'Lawful Good', N'Player 1')
INSERT INTO [dbo].[DnD5ePlayerCharacter] ([Id], [Name], [Race], [Class], [Level], [charStrength], [charDexterity], [charConstitution], [charIntelligence], [charWisdom], [charCharisma], [HitPoints], [Background], [Alignment], [Player]) VALUES (2, N'ALsoeq', N'Half-Orc', N'Barbarian', 12, 5, 5, 5, 5, 5, 5, 15, N'ASDjqwe', N'Neutral', N'Blerp')
INSERT INTO [dbo].[DnD5ePlayerCharacter] ([Id], [Name], [Race], [Class], [Level], [charStrength], [charDexterity], [charConstitution], [charIntelligence], [charWisdom], [charCharisma], [HitPoints], [Background], [Alignment], [Player]) VALUES (3, N'Mark', N'Elf', N'Barbarian', 1, 17, 15, 16, 10, 14, 15, 15, N'Soldier', N'Neutral Good', N'Player 1')
INSERT INTO [dbo].[DnD5ePlayerCharacter] ([Id], [Name], [Race], [Class], [Level], [charStrength], [charDexterity], [charConstitution], [charIntelligence], [charWisdom], [charCharisma], [HitPoints], [Background], [Alignment], [Player]) VALUES (4, N'Bord', N'Dragonborn', N'Barbarian', 1, 15, 15, 15, 15, 15, 15, 40, N'Morpsaed', N'Lawful Good', N'Player 2')
SET IDENTITY_INSERT [dbo].[DnD5ePlayerCharacter] OFF

SET IDENTITY_INSERT [dbo].[DnD5ePlayerItem] ON
INSERT INTO [dbo].[DnD5ePlayerItem] ([Id], [Name], [Description], [WeightInPounds], [CostInGoldPieces], [Notes]) VALUES (1, N'Hempen rope', N'Rope, whether made of hemp or silk, has 2 hit points and can be burst with a DC 17 Strength check.', 10, 1, N'This is my test note and I''m making longer to make sure it wraps, oh god, please work. Please geez.')
INSERT INTO [dbo].[DnD5ePlayerItem] ([Id], [Name], [Description], [WeightInPounds], [CostInGoldPieces], [Notes]) VALUES (2, N' Rope of Climbing ', N'This 60-foot length of silk rope weighs 3 pounds and can hold up to 3,000 pounds. If you hold one end of the rope and use an action to speak the command word, the rope animates. As a bonus action, you can command the other end to move toward a destination you choose. That end moves 10 feet on your turn when you first command it and 10 feet on each of your turns until reaching its destination, up to its maximum length away, or until you tell it to stop. You can also tell the rope to fasten itself securely to an object or to unfasten itself, to knot or unknot itself, or to coil itself for carrying.

If you tell the rope to knot, large knots appear at 1-foot intervals along the rope. While knotted, the rope shortens to a 50-foot length and grants advantage on checks made to climb it.

The rope has AC 20 and 20 hit points. It regains 1 hit point every 5 minutes as long as it has at least 1 hit point. If the rope drops to 0 hit points, it is destroyed', 3, 50, NULL)
SET IDENTITY_INSERT [dbo].[DnD5ePlayerItem] OFF

SET IDENTITY_INSERT [dbo].[DnD5eWeapon] ON
INSERT INTO [dbo].[DnD5eWeapon] ([Id], [Name], [Description], [WeightInPounds], [CostInGoldPieces], [WeaponType], [DamageDice], [NumberOfDice], [BonusDamage], [IsMagical]) VALUES (1, N'Stabby Stick', N'It stabs real good', 1, 10, 7, 8, 2, 2, 1)
INSERT INTO [dbo].[DnD5eWeapon] ([Id], [Name], [Description], [WeightInPounds], [CostInGoldPieces], [WeaponType], [DamageDice], [NumberOfDice], [BonusDamage], [IsMagical]) VALUES (2, N'Bashy Rock', N'Rock and Roll', 500, 0, 6, 8, 20, 0, 0)
SET IDENTITY_INSERT [dbo].[DnD5eWeapon] OFF

SET IDENTITY_INSERT [dbo].[Spell] ON
INSERT INTO [dbo].[Spell] ([Id], [Name], [Description], [SpellLevel], [CastingTime], [School], [DamageDice], [NumberOfDice], [Bonus], [Range], [Duration], [Save], [Effect], [Components], [IsConcentration], [IsRitual]) VALUES (1, N'Revivify', N'You touch a creature that has died within the last minute. That creature returns to life with 1 hit point. This spell can''t return to life a creature that has died of old age, nor can it restore any missing body parts.', 0, N'1 Action', N'3', NULL, NULL, NULL, N'Touch', N'Instantaneous', N'None', N'Healing', N'Diamonds worth 300 gp, which the spell consumes.', 0, 0)
INSERT INTO [dbo].[Spell] ([Id], [Name], [Description], [SpellLevel], [CastingTime], [School], [DamageDice], [NumberOfDice], [Bonus], [Range], [Duration], [Save], [Effect], [Components], [IsConcentration], [IsRitual]) VALUES (2, N'Fireball', N'A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one.

The fire spreads around corners. It ignites flammable objects in the area that aren''t being worn or carried.

At Higher Levels. When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd.', 0, N'1 Action', N'3', 6, 8, N'0', N'150 ft w/ 20 ft radius', N'Instantaneous', N'Dex', N'Fire', N'A tiny ball of bat guano and sulfur.', 0, 0)
INSERT INTO [dbo].[Spell] ([Id], [Name], [Description], [SpellLevel], [CastingTime], [School], [DamageDice], [NumberOfDice], [Bonus], [Range], [Duration], [Save], [Effect], [Components], [IsConcentration], [IsRitual]) VALUES (3, N'Abi-Dalzim’s Horrid Wilting', N'You draw the moisture from every creature in a 30-foot cube centered on a point you choose within range. Each creature in that area must make a Constitution saving throw. Constructs and undead aren’t affected, and plants and water elementals make this saving throw with disadvantage. A creature takes 12d8 necrotic damage on a failed save, or half as much damage on a successful one.

Nonmagical plants in the area that aren’t creatures, such as trees and shrubs, wither and die instantly.', 0, N'1 Action', N'8', NULL, NULL, NULL, N'150 ft w/ 30 ft cube', N'Instantaneous', N'Con', N'Necrotic', N'A bit of sponge', 0, 0)
SET IDENTITY_INSERT [dbo].[Spell] OFF
