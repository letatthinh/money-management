using DataLayer.DomainModels.Abstracts;
using DataLayer.DomainModels.ContactGroup;
using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("User", Schema = "user")]
    public class User : BaseModel
    {
        [StringLength(20)]
        public string UserName { get; set; } = null!;

        [StringLength(50)]
        public string Password { get; set; } = null!;

        public UserStatus Status { get; set; } = UserStatus.Active;

        [StringLength(60)]
        public string DisplayName { get; set; } = null!;

        [StringLength(20)]
        public string FirstName { get; set; } = null!;

        [StringLength(20)]
        public string? MiddleName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; } = null!;

        public DateOnly Birthday { get; set; }

        public ICollection<UserEmail>? Emails { get; set; } = new List<UserEmail>();

        public ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();

        /// <summary>
        /// List of contacts belong to this user.
        /// </summary>
        public ICollection<UserContacts>? Contacts { get; set; } = new List<UserContacts>();

        /// <summary>
        /// List of users belong to this contact.
        /// </summary>
        public ICollection<UserContacts>? Users { get; set; } = new List<UserContacts>();

        public ICollection<CustomContact>? CustomContacts { get; set; } = new List<CustomContact>();

        public ICollection<UserMoneyTransactionCategory>? UserTransactionCategories { get; set; } = new List<UserMoneyTransactionCategory>();

        public ICollection<UserContactIncomeDetail>? UserContactIncomeDetails { get; set; } = new List<UserContactIncomeDetail>();

        public ICollection<UserContactLoanOwner>? UserContactLoanOwners { get; set; } = new List<UserContactLoanOwner>();

        public ICollection<UserContactLoanPaymentDetail>? UserContactLoanPaymentDetails { get; set; } = new List<UserContactLoanPaymentDetail>();

        public ICollection<UserContactDebtor>? UserContactDebtors { get; set; } = new List<UserContactDebtor>();

        public ICollection<UserContactLendingPaymentDetail>? UserContactLendingPaymentDetails { get; set; } = new List<UserContactLendingPaymentDetail>();

        public ICollection<UserContactInvestment>? UserContactInvestments { get; set; } = new List<UserContactInvestment>();

        public ICollection<UserInvestmentCategory>? UserInvestmentCategories { get; set; } = new List<UserInvestmentCategory>();
    }
}