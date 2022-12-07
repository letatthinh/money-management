using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "contact");

            migrationBuilder.EnsureSchema(
                name: "moneytransaction");

            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomContact",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContact_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContacts",
                schema: "user",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => new { x.UserId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_UserContacts_User_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContacts_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserEmail",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEmail_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInvestmentCategory",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInvestmentCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInvestmentCategory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMoneyTransactionCategory",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMoneyTransactionCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMoneyTransactionCategory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "user",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "user",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomContactEmail",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomContactId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContactEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContactEmail_CustomContact_CustomContactId",
                        column: x => x.CustomContactId,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_CustomContact_Id",
                        column: x => x.Id,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Place",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_CustomContact_Id",
                        column: x => x.Id,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MoneyTransaction",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMoneyTransactionCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyTransaction_UserMoneyTransactionCategory_UserMoneyTransactionCategoryId",
                        column: x => x.UserMoneyTransactionCategoryId,
                        principalSchema: "user",
                        principalTable: "UserMoneyTransactionCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_MoneyTransaction_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "MoneyTransaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Income",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Income_MoneyTransaction_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "MoneyTransaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Investment",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserInvestmentCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    AmountOfMoneyEarned = table.Column<float>(type: "real", nullable: false),
                    MoneyEarnedCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AmountOfExchangedMoneyEarned = table.Column<float>(type: "real", nullable: true),
                    ExchangedMoneyEarnedCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ExchangeRateOfMoneyEarned = table.Column<float>(type: "real", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfMoney = table.Column<float>(type: "real", nullable: false),
                    MoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AmountOfExchangedMoney = table.Column<float>(type: "real", nullable: true),
                    ExchangedMoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ExchangeRate = table.Column<float>(type: "real", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestRate = table.Column<float>(type: "real", nullable: false),
                    InterestType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investment_MoneyTransaction_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "MoneyTransaction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Investment_UserInvestmentCategory_UserInvestmentCategoryId",
                        column: x => x.UserInvestmentCategoryId,
                        principalSchema: "user",
                        principalTable: "UserInvestmentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lending",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AmountOfMoneyReturned = table.Column<float>(type: "real", nullable: false),
                    MoneyReturnedCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfMoney = table.Column<float>(type: "real", nullable: false),
                    MoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AmountOfExchangedMoney = table.Column<float>(type: "real", nullable: true),
                    ExchangedMoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ExchangeRate = table.Column<float>(type: "real", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestRate = table.Column<float>(type: "real", nullable: false),
                    InterestType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lending", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lending_MoneyTransaction_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "MoneyTransaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AmountOfMoneyRepaid = table.Column<float>(type: "real", nullable: false),
                    MoneyRepaidCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfMoney = table.Column<float>(type: "real", nullable: false),
                    MoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AmountOfExchangedMoney = table.Column<float>(type: "real", nullable: true),
                    ExchangedMoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ExchangeRate = table.Column<float>(type: "real", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestRate = table.Column<float>(type: "real", nullable: false),
                    InterestType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loan_MoneyTransaction_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "MoneyTransaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpenseDetail",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<long>(type: "bigint", nullable: false),
                    AmountOfMoney = table.Column<float>(type: "real", nullable: false),
                    MoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AmountOfExchangedMoney = table.Column<float>(type: "real", nullable: true),
                    ExchangedMoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ExchangeRate = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseDetail_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalSchema: "moneytransaction",
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeDetail",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncomeId = table.Column<long>(type: "bigint", nullable: false),
                    AmountOfMoney = table.Column<float>(type: "real", nullable: false),
                    MoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AmountOfExchangedMoney = table.Column<float>(type: "real", nullable: true),
                    ExchangedMoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ExchangeRate = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeDetail_Income_IncomeId",
                        column: x => x.IncomeId,
                        principalSchema: "moneytransaction",
                        principalTable: "Income",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomContactInvestment",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CustomContactId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContactInvestment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContactInvestment_CustomContact_CustomContactId",
                        column: x => x.CustomContactId,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomContactInvestment_Investment_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "Investment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserContactInvestment",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactInvestment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactInvestment_Investment_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "Investment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContactInvestment_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomContactDebtor",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CustomContactId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContactDebtor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContactDebtor_CustomContact_CustomContactId",
                        column: x => x.CustomContactId,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomContactDebtor_Lending_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "Lending",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LendingPaymentDetail",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LendingId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfMoney = table.Column<float>(type: "real", nullable: false),
                    MoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AmountOfExchangedMoney = table.Column<float>(type: "real", nullable: true),
                    ExchangedMoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ExchangeRate = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LendingPaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LendingPaymentDetail_Lending_LendingId",
                        column: x => x.LendingId,
                        principalSchema: "moneytransaction",
                        principalTable: "Lending",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContactDebtor",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactDebtor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactDebtor_Lending_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "Lending",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContactDebtor_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomContactLoanOwner",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CustomContactId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContactLoanOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContactLoanOwner_CustomContact_CustomContactId",
                        column: x => x.CustomContactId,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomContactLoanOwner_Loan_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "Loan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoanPaymentDetail",
                schema: "moneytransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfMoney = table.Column<float>(type: "real", nullable: false),
                    MoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AmountOfExchangedMoney = table.Column<float>(type: "real", nullable: true),
                    ExchangedMoneyCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ExchangeRate = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanPaymentDetail_Loan_LoanId",
                        column: x => x.LoanId,
                        principalSchema: "moneytransaction",
                        principalTable: "Loan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContactLoanOwner",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactLoanOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactLoanOwner_Loan_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "Loan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContactLoanOwner_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomContactExpenseDetail",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CustomContactId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContactExpenseDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContactExpenseDetail_CustomContact_CustomContactId",
                        column: x => x.CustomContactId,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomContactExpenseDetail_ExpenseDetail_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "ExpenseDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserContactExpenseDetail",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactExpenseDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactExpenseDetail_ExpenseDetail_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "ExpenseDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContactExpenseDetail_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomContactIncomeDetail",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CustomContactId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContactIncomeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContactIncomeDetail_CustomContact_CustomContactId",
                        column: x => x.CustomContactId,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomContactIncomeDetail_IncomeDetail_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "IncomeDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserContactIncomeDetail",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactIncomeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactIncomeDetail_IncomeDetail_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "IncomeDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContactIncomeDetail_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomContactLendingPaymentDetail",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CustomContactId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContactLendingPaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContactLendingPaymentDetail_CustomContact_CustomContactId",
                        column: x => x.CustomContactId,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomContactLendingPaymentDetail_LendingPaymentDetail_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "LendingPaymentDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserContactLendingPaymentDetail",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactLendingPaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactLendingPaymentDetail_LendingPaymentDetail_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "LendingPaymentDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContactLendingPaymentDetail_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomContactLoanPaymentDetail",
                schema: "contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CustomContactId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContactLoanPaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContactLoanPaymentDetail_CustomContact_CustomContactId",
                        column: x => x.CustomContactId,
                        principalSchema: "contact",
                        principalTable: "CustomContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomContactLoanPaymentDetail_LoanPaymentDetail_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "LoanPaymentDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserContactLoanPaymentDetail",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactLoanPaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactLoanPaymentDetail_LoanPaymentDetail_Id",
                        column: x => x.Id,
                        principalSchema: "moneytransaction",
                        principalTable: "LoanPaymentDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContactLoanPaymentDetail_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomContact_UserId",
                schema: "contact",
                table: "CustomContact",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactDebtor_CustomContactId",
                schema: "contact",
                table: "CustomContactDebtor",
                column: "CustomContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactEmail_CustomContactId",
                schema: "contact",
                table: "CustomContactEmail",
                column: "CustomContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactExpenseDetail_CustomContactId",
                schema: "contact",
                table: "CustomContactExpenseDetail",
                column: "CustomContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactIncomeDetail_CustomContactId",
                schema: "contact",
                table: "CustomContactIncomeDetail",
                column: "CustomContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactInvestment_CustomContactId",
                schema: "contact",
                table: "CustomContactInvestment",
                column: "CustomContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactLendingPaymentDetail_CustomContactId",
                schema: "contact",
                table: "CustomContactLendingPaymentDetail",
                column: "CustomContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactLoanOwner_CustomContactId",
                schema: "contact",
                table: "CustomContactLoanOwner",
                column: "CustomContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactLoanPaymentDetail_CustomContactId",
                schema: "contact",
                table: "CustomContactLoanPaymentDetail",
                column: "CustomContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetail_ExpenseId",
                schema: "moneytransaction",
                table: "ExpenseDetail",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeDetail_IncomeId",
                schema: "moneytransaction",
                table: "IncomeDetail",
                column: "IncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Investment_UserInvestmentCategoryId",
                schema: "moneytransaction",
                table: "Investment",
                column: "UserInvestmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LendingPaymentDetail_LendingId",
                schema: "moneytransaction",
                table: "LendingPaymentDetail",
                column: "LendingId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPaymentDetail_LoanId",
                schema: "moneytransaction",
                table: "LoanPaymentDetail",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransaction_UserMoneyTransactionCategoryId",
                schema: "moneytransaction",
                table: "MoneyTransaction",
                column: "UserMoneyTransactionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactDebtor_UserId",
                schema: "user",
                table: "UserContactDebtor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactExpenseDetail_UserId",
                schema: "user",
                table: "UserContactExpenseDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactIncomeDetail_UserId",
                schema: "user",
                table: "UserContactIncomeDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactInvestment_UserId",
                schema: "user",
                table: "UserContactInvestment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactLendingPaymentDetail_UserId",
                schema: "user",
                table: "UserContactLendingPaymentDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactLoanOwner_UserId",
                schema: "user",
                table: "UserContactLoanOwner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactLoanPaymentDetail_UserId",
                schema: "user",
                table: "UserContactLoanPaymentDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_ContactId",
                schema: "user",
                table: "UserContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmail_UserId",
                schema: "user",
                table: "UserEmail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestmentCategory_UserId",
                schema: "user",
                table: "UserInvestmentCategory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMoneyTransactionCategory_UserId",
                schema: "user",
                table: "UserMoneyTransactionCategory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "user",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomContactDebtor",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "CustomContactEmail",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "CustomContactExpenseDetail",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "CustomContactIncomeDetail",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "CustomContactInvestment",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "CustomContactLendingPaymentDetail",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "CustomContactLoanOwner",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "CustomContactLoanPaymentDetail",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "Place",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "UserContactDebtor",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserContactExpenseDetail",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserContactIncomeDetail",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserContactInvestment",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserContactLendingPaymentDetail",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserContactLoanOwner",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserContactLoanPaymentDetail",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserContacts",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserEmail",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "user");

            migrationBuilder.DropTable(
                name: "CustomContact",
                schema: "contact");

            migrationBuilder.DropTable(
                name: "ExpenseDetail",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "IncomeDetail",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "Investment",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "LendingPaymentDetail",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "LoanPaymentDetail",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "user");

            migrationBuilder.DropTable(
                name: "Expense",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "Income",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "UserInvestmentCategory",
                schema: "user");

            migrationBuilder.DropTable(
                name: "Lending",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "Loan",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "MoneyTransaction",
                schema: "moneytransaction");

            migrationBuilder.DropTable(
                name: "UserMoneyTransactionCategory",
                schema: "user");

            migrationBuilder.DropTable(
                name: "User",
                schema: "user");
        }
    }
}
