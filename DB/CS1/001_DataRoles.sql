USE [THITN]
GO

DECLARE @RoleName sysname
set @RoleName = N'TRUONG'

IF @RoleName <> N'public' and (select is_fixed_role from sys.database_principals where name = @RoleName) = 0
BEGIN
    DECLARE @RoleMemberName sysname
    DECLARE Member_Cursor CURSOR FOR
    select [name]
    from sys.database_principals 
    where principal_id in ( 
        select member_principal_id
        from sys.database_role_members
        where role_principal_id in (
            select principal_id
            FROM sys.database_principals where [name] = @RoleName AND type = 'R'))

    OPEN Member_Cursor;

    FETCH NEXT FROM Member_Cursor
    into @RoleMemberName
    
    DECLARE @SQL NVARCHAR(4000)

    WHILE @@FETCH_STATUS = 0
    BEGIN
        
        SET @SQL = 'ALTER ROLE '+ QUOTENAME(@RoleName,'[') +' DROP MEMBER '+ QUOTENAME(@RoleMemberName,'[')
        EXEC(@SQL)
        
        FETCH NEXT FROM Member_Cursor
        into @RoleMemberName
    END;

    CLOSE Member_Cursor;
    DEALLOCATE Member_Cursor;
END
/****** Object:  DatabaseRole [TRUONG]    Script Date: 1/7/2026 9:02:49 PM ******/
DROP ROLE [TRUONG]
GO

DECLARE @RoleName sysname
set @RoleName = N'SINHVIEN'

IF @RoleName <> N'public' and (select is_fixed_role from sys.database_principals where name = @RoleName) = 0
BEGIN
    DECLARE @RoleMemberName sysname
    DECLARE Member_Cursor CURSOR FOR
    select [name]
    from sys.database_principals 
    where principal_id in ( 
        select member_principal_id
        from sys.database_role_members
        where role_principal_id in (
            select principal_id
            FROM sys.database_principals where [name] = @RoleName AND type = 'R'))

    OPEN Member_Cursor;

    FETCH NEXT FROM Member_Cursor
    into @RoleMemberName
    
    DECLARE @SQL NVARCHAR(4000)

    WHILE @@FETCH_STATUS = 0
    BEGIN
        
        SET @SQL = 'ALTER ROLE '+ QUOTENAME(@RoleName,'[') +' DROP MEMBER '+ QUOTENAME(@RoleMemberName,'[')
        EXEC(@SQL)
        
        FETCH NEXT FROM Member_Cursor
        into @RoleMemberName
    END;

    CLOSE Member_Cursor;
    DEALLOCATE Member_Cursor;
END
/****** Object:  DatabaseRole [SINHVIEN]    Script Date: 1/7/2026 9:02:49 PM ******/
DROP ROLE [SINHVIEN]
GO

DECLARE @RoleName sysname
set @RoleName = N'GIANGVIEN'

IF @RoleName <> N'public' and (select is_fixed_role from sys.database_principals where name = @RoleName) = 0
BEGIN
    DECLARE @RoleMemberName sysname
    DECLARE Member_Cursor CURSOR FOR
    select [name]
    from sys.database_principals 
    where principal_id in ( 
        select member_principal_id
        from sys.database_role_members
        where role_principal_id in (
            select principal_id
            FROM sys.database_principals where [name] = @RoleName AND type = 'R'))

    OPEN Member_Cursor;

    FETCH NEXT FROM Member_Cursor
    into @RoleMemberName
    
    DECLARE @SQL NVARCHAR(4000)

    WHILE @@FETCH_STATUS = 0
    BEGIN
        
        SET @SQL = 'ALTER ROLE '+ QUOTENAME(@RoleName,'[') +' DROP MEMBER '+ QUOTENAME(@RoleMemberName,'[')
        EXEC(@SQL)
        
        FETCH NEXT FROM Member_Cursor
        into @RoleMemberName
    END;

    CLOSE Member_Cursor;
    DEALLOCATE Member_Cursor;
END
/****** Object:  DatabaseRole [GIANGVIEN]    Script Date: 1/7/2026 9:02:49 PM ******/
DROP ROLE [GIANGVIEN]
GO

DECLARE @RoleName sysname
set @RoleName = N'COSO'

IF @RoleName <> N'public' and (select is_fixed_role from sys.database_principals where name = @RoleName) = 0
BEGIN
    DECLARE @RoleMemberName sysname
    DECLARE Member_Cursor CURSOR FOR
    select [name]
    from sys.database_principals 
    where principal_id in ( 
        select member_principal_id
        from sys.database_role_members
        where role_principal_id in (
            select principal_id
            FROM sys.database_principals where [name] = @RoleName AND type = 'R'))

    OPEN Member_Cursor;

    FETCH NEXT FROM Member_Cursor
    into @RoleMemberName
    
    DECLARE @SQL NVARCHAR(4000)

    WHILE @@FETCH_STATUS = 0
    BEGIN
        
        SET @SQL = 'ALTER ROLE '+ QUOTENAME(@RoleName,'[') +' DROP MEMBER '+ QUOTENAME(@RoleMemberName,'[')
        EXEC(@SQL)
        
        FETCH NEXT FROM Member_Cursor
        into @RoleMemberName
    END;

    CLOSE Member_Cursor;
    DEALLOCATE Member_Cursor;
END
/****** Object:  DatabaseRole [COSO]    Script Date: 1/7/2026 9:02:49 PM ******/
DROP ROLE [COSO]
GO
/****** Object:  DatabaseRole [COSO]    Script Date: 1/7/2026 9:02:49 PM ******/
CREATE ROLE [COSO]
GO
/****** Object:  DatabaseRole [GIANGVIEN]    Script Date: 1/7/2026 9:02:49 PM ******/
CREATE ROLE [GIANGVIEN]
GO
/****** Object:  DatabaseRole [SINHVIEN]    Script Date: 1/7/2026 9:02:49 PM ******/
CREATE ROLE [SINHVIEN]
GO
/****** Object:  DatabaseRole [TRUONG]    Script Date: 1/7/2026 9:02:49 PM ******/
CREATE ROLE [TRUONG]
GO
ALTER ROLE [db_owner] ADD MEMBER [COSO]
GO
ALTER ROLE [db_owner] ADD MEMBER [GIANGVIEN]
GO
ALTER ROLE [db_owner] ADD MEMBER [SINHVIEN]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [TRUONG]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [TRUONG]
GO
ALTER ROLE [db_datareader] ADD MEMBER [TRUONG]
GO
