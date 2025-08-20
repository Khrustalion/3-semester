using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type transaction_type as enum
    (
        'withdraw',
        'deposit',
        'create'
        );
    
    create table accounts
    (
        account_id bigserial primary key ,
        account_number bigint not null ,
        balance money not null ,
        pin int not null
    );
    
    create table transactions
    (
        transaction_id bigserial primary key ,
        account_id bigint not null references accounts(account_id) ,
        type transaction_type not null
    );
    
    create table admins
    (
        admin_password bigint not null
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table transactions;
    drop table accounts;
    
    drop type transaction_type;
    """;
}
