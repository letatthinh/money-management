using Common.Constants;
using DataLayer.DomainModels.ContactGroup;
using DataLayer.DomainModels.TransactionGroup;
using DataLayer.DomainModels.UserGroup;
using DataLayer.Helpers.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataLayer.DatabaseContexts
{
    public class MoneyManagementDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(DatabaseConstants.ConnectionString)
                .LogTo(Console.WriteLine, LogLevel.Debug);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateOnly>()
                .HaveConversion<DateOnlyToDateTimeConverter>()
                .HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE: Composite primary keys
            modelBuilder
                .Entity<UserRoles>()
                .HasKey(userRole => new { userRole.UserId, userRole.RoleId });

            modelBuilder
                .Entity<UserContacts>(userFriends =>
                {
                    // NOTE: Composite primary keys
                    userFriends
                        .HasKey(userFriend => new { userFriend.UserId, userFriend.ContactId });

                    userFriends
                        .HasOne(userFriend => userFriend.User)
                        .WithMany(user => user.Contacts)
                        .HasForeignKey(userFriend => userFriend.UserId)
                        .OnDelete(DeleteBehavior.NoAction);

                    userFriends
                        .HasOne(userFriend => userFriend.Contact)
                        .WithMany(user => user.Users)
                        .HasForeignKey(userFriend => userFriend.ContactId)
                        .OnDelete(DeleteBehavior.NoAction);
                });
        }

        // Contact group --------------------------------------------------------------------------------------------------

        public DbSet<CustomContact> CustomContacts { get; set; } = null!;

        public DbSet<CustomContactDebtor> CustomContactDebtors { get; set; } = null!;

        public DbSet<CustomContactEmail> CustomContactEmails { get; set; } = null!;

        public DbSet<CustomContactExpenseDetail> CustomContactExpenseDetails { get; set; } = null!;

        public DbSet<CustomContactIncomeDetail> CustomContactIncomeDetails { get; set; } = null!;

        public DbSet<CustomContactInvestment> CustomContactInvestments { get; set; } = null!;

        public DbSet<CustomContactLendingPaymentDetail> CustomContactLendingPaymentDetails { get; set; } = null!;

        public DbSet<CustomContactLoanOwner> CustomContactLoanOwners { get; set; } = null!;

        public DbSet<CustomContactLoanPaymentDetail> CustomContactLoanPaymentDetails { get; set; } = null!;

        public DbSet<Place> Places { get; set; } = null!;

        public DbSet<Person> Persons { get; set; } = null!;

        // Money transaction group ----------------------------------------------------------------------------------------

        public DbSet<UserInvestmentCategory> UserInvestmentCategories { get; set; } = null!;

        public DbSet<Expense> Expenses { get; set; } = null!;

        public DbSet<ExpenseDetail> ExpenseDetails { get; set; } = null!;

        public DbSet<Income> Incomes { get; set; } = null!;

        public DbSet<IncomeDetail> IncomeDetails { get; set; } = null!;

        public DbSet<Investment> Investments { get; set; } = null!;

        public DbSet<Lending> Lendings { get; set; } = null!;

        public DbSet<LendingPaymentDetail> LendingPaymentDetails { get; set; } = null!;

        public DbSet<Loan> Loans { get; set; } = null!;

        public DbSet<LoanPaymentDetail> LoanPaymentDetails { get; set; } = null!;

        public DbSet<MoneyTransaction> MoneyTransactions { get; set; } = null!;

        // User group -----------------------------------------------------------------------------------------------------

        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<UserContactDebtor> UserContactDebtors { get; set; } = null!;

        public DbSet<UserContactExpenseDetail> UserContactExpenseDetails { get; set; } = null!;

        public DbSet<UserContactIncomeDetail> UserContactIncomeDetails { get; set; } = null!;

        public DbSet<UserContactInvestment> UserContactInvestments { get; set; } = null!;

        public DbSet<UserContactLendingPaymentDetail> UserContactLendingPaymentDetails { get; set; } = null!;

        public DbSet<UserContactLoanOwner> UserContactLoanOwners { get; set; } = null!;

        public DbSet<UserContactLoanPaymentDetail> UserContactLoanPaymentDetails { get; set; } = null!;

        public DbSet<UserContacts> UserContacts { get; set; } = null!;

        public DbSet<UserEmail> UserEmails { get; set; } = null!;

        public DbSet<UserMoneyTransactionCategory> UserMoneyTransactionCategories { get; set; } = null!;

        public DbSet<UserRoles> UserRoles { get; set; } = null!;
    }
}