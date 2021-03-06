﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace OCMovers_MC4.Models
{
    //public class UsersContext : DbContext
    //{
    //    public UsersContext()
    //        : base("DefaultConnection")
    //    {
    //    }

    //    public DbSet<UserProfile> UserProfiles { get; set; }
    //}

    //[Table("UserProfile")]
    //public class UserProfile
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int UserId { get; set; }
    //    public string UserName { get; set; }
    //}

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddressAttribute]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [MaxLength(150)]
        [Display(Name = "First Name")]
        public string BFirstName { get; set; }

        [MaxLength(150)]
        [Display(Name = "Last Name")]
        public string BLastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        [MaxLength(20)]
        public string BPhone { get; set; }

        //Personal Information.
        [Display(Name = "Address Line 1")]
        [MaxLength(250)]
        public string BAddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [MaxLength(250)]
        public string BAddressLine2 { get; set; }

        [Display(Name = "City")]
        [MaxLength(250)]
        public string BCityProvince { get; set; }

        [Display(Name = "State / Province")]
        public string BState { get; set; }

        [Display(Name = "Country")]
        public int? BCountry { get; set; }

        [Display(Name = "Postal")]
        public string BPostal { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [DefaultValue(false)]
        public bool SoftDelete { get; set; }

        //public string test { get; set; }

    }

    #region Added Code

    [Table("webpages_Membership")]
    public class Membership
    {
        public Membership()
        {
            Roles = new List<Role>();
            OAuthMemberships = new List<OAuthMembership>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(128)]
        public string ConfirmationToken { get; set; }
        public bool? IsConfirmed { get; set; }
        public DateTime? LastPasswordFailureDate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        [Required, StringLength(128)]
        public string Password { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        [Required, StringLength(128)]
        public string PasswordSalt { get; set; }
        [StringLength(128)]
        public string PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        public ICollection<Role> Roles { get; set; }

        [ForeignKey("UserId")]
        public ICollection<OAuthMembership> OAuthMemberships { get; set; }
    }

    [Table("webpages_OAuthMembership")]
    public class OAuthMembership
    {
        [Key, Column(Order = 0), StringLength(30)]
        public string Provider { get; set; }

        [Key, Column(Order = 1), StringLength(100)]
        public string ProviderUserId { get; set; }

        public int UserId { get; set; }

        [Column("UserId"), InverseProperty("OAuthMemberships")]
        public Membership User { get; set; }
    }

    [Table("webpages_Roles")]
    public class Role
    {
        public Role()
        {
            Members = new List<Membership>();
        }

        [Key]
        public int RoleId { get; set; }
        [StringLength(256)]
        public string RoleName { get; set; }

        public ICollection<Membership> Members { get; set; }
    }

    #endregion

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
