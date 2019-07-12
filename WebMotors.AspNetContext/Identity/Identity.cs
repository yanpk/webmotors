using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebMotors.AspNetContext.Identity
{
    public interface IUserManager
    {
        ILogger Logger { get; set; }
        bool SupportsUserRole { get; }
        bool SupportsUserLogin { get; }
        bool SupportsUserEmail { get; }
        bool SupportsUserPhoneNumber { get; }
        bool SupportsUserClaim { get; }
        bool SupportsUserLockout { get; }
        bool SupportsUserTwoFactor { get; }
        bool SupportsQueryableUsers { get; }
        Task<IEnumerable<IIdentityError>> AddToRoleAsync(IApplicationUser user, string role);
        Task<IEnumerable<IIdentityError>> AddToRolesAsync(IApplicationUser user, IEnumerable<string> roles);
        Task<IEnumerable<IIdentityError>> ChangeEmailAsync(IApplicationUser user, string newEmail, string token);
        Task<IEnumerable<IIdentityError>> ChangePasswordAsync(IApplicationUser user, string currentPassword, string newPassword);
        Task<IEnumerable<IIdentityError>> ChangePhoneNumberAsync(IApplicationUser user, string phoneNumber, string token);
        Task<bool> CheckPasswordAsync(IApplicationUser user, string password);
        Task<IEnumerable<IIdentityError>> ConfirmEmailAsync(IApplicationUser user, string token);
        Task<int> CountRecoveryCodesAsync(IApplicationUser user);
        Task<IEnumerable<IIdentityError>> CreateAsync(IApplicationUser user, string password);
        Task<IEnumerable<IIdentityError>> CreateAsync(IApplicationUser user);
        Task<byte[]> CreateSecurityTokenAsync(IApplicationUser user);
        Task<IEnumerable<IIdentityError>> DeleteAsync(IApplicationUser user);
        void Dispose();
        Task<IApplicationUser> FindByEmailAsync(string email);
        Task<IApplicationUser> FindByIdAsync(string userId);
        Task<IApplicationUser> FindByLoginAsync(string loginProvider, string providerKey);
        Task<IApplicationUser> FindByNameAsync(string userName);
        Task<string> GenerateChangeEmailTokenAsync(IApplicationUser user, string newEmail);
        Task<string> GenerateChangePhoneNumberTokenAsync(IApplicationUser user, string phoneNumber);
        Task<string> GenerateConcurrencyStampAsync(IApplicationUser user);
        Task<string> GenerateEmailConfirmationTokenAsync(IApplicationUser user);
        string GenerateNewAuthenticatorKey();
        Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(IApplicationUser user, int number);
        Task<string> GeneratePasswordResetTokenAsync(IApplicationUser user);
        Task<string> GenerateTwoFactorTokenAsync(IApplicationUser user, string tokenProvider);
        Task<string> GenerateUserTokenAsync(IApplicationUser user, string tokenProvider, string purpose);
        Task<int> GetAccessFailedCountAsync(IApplicationUser user);
        Task<string> GetAuthenticationTokenAsync(IApplicationUser user, string loginProvider, string tokenName);
        Task<string> GetAuthenticatorKeyAsync(IApplicationUser user);
        Task<IList<Claim>> GetClaimsAsync(IApplicationUser user);
        Task<string> GetEmailAsync(IApplicationUser user);
        Task<bool> GetLockoutEnabledAsync(IApplicationUser user);
        Task<DateTimeOffset?> GetLockoutEndDateAsync(IApplicationUser user);
        //Task<IList<UserLoginInfo>> GetLoginsAsync(IApplicationUser user);
        Task<string> GetPhoneNumberAsync(IApplicationUser user);
        Task<IList<string>> GetRolesAsync(IApplicationUser user);
        Task<string> GetSecurityStampAsync(IApplicationUser user);
        Task<bool> GetTwoFactorEnabledAsync(IApplicationUser user);
        Task<IApplicationUser> GeIApplicationUserAsync(ClaimsPrincipal principal);
        string GeIApplicationUserId(ClaimsPrincipal principal);
        Task<string> GeIApplicationUserIdAsync(IApplicationUser user);
        string GeIApplicationUserName(ClaimsPrincipal principal);
        Task<string> GeIApplicationUserNameAsync(IApplicationUser user);
        Task<IList<IApplicationUser>> GeIApplicationUsersForClaimAsync(Claim claim);
        Task<IList<IApplicationUser>> GeIApplicationUsersInRoleAsync(string roleName);
        Task<IList<string>> GetValidTwoFactorProvidersAsync(IApplicationUser user);
        Task<bool> HasPasswordAsync(IApplicationUser user);
        Task<bool> IsEmailConfirmedAsync(IApplicationUser user);
        Task<bool> IsInRoleAsync(IApplicationUser user, string role);
        Task<bool> IsLockedOutAsync(IApplicationUser user);
        Task<bool> IsPhoneNumberConfirmedAsync(IApplicationUser user);
        string NormalizeKey(string key);
        Task<IEnumerable<IIdentityError>> RedeemTwoFactorRecoveryCodeAsync(IApplicationUser user, string code);
        //void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<IApplicationUser> provider);
        Task<IEnumerable<IIdentityError>> RemoveAuthenticationTokenAsync(IApplicationUser user, string loginProvider, string tokenName);
        Task<IEnumerable<IIdentityError>> RemoveClaimAsync(IApplicationUser user, Claim claim);
        Task<IEnumerable<IIdentityError>> RemoveClaimsAsync(IApplicationUser user, IEnumerable<Claim> claims);
        Task<IEnumerable<IIdentityError>> RemoveFromRoleAsync(IApplicationUser user, string role);
        Task<IEnumerable<IIdentityError>> RemoveFromRolesAsync(IApplicationUser user, IEnumerable<string> roles);
        Task<IEnumerable<IIdentityError>> RemoveLoginAsync(IApplicationUser user, string loginProvider, string providerKey);
        Task<IEnumerable<IIdentityError>> RemovePasswordAsync(IApplicationUser user);
        Task<IEnumerable<IIdentityError>> ReplaceClaimAsync(IApplicationUser user, Claim claim, Claim newClaim);
        Task<IEnumerable<IIdentityError>> ResetAccessFailedCountAsync(IApplicationUser user);
        Task<IEnumerable<IIdentityError>> ResetAuthenticatorKeyAsync(IApplicationUser user);
        Task<IEnumerable<IIdentityError>> ResetPasswordAsync(IApplicationUser user, string token, string newPassword);
        Task<IEnumerable<IIdentityError>> SetAuthenticationTokenAsync(IApplicationUser user, string loginProvider, string tokenName, string tokenValue);
        Task<IEnumerable<IIdentityError>> SetEmailAsync(IApplicationUser user, string email);
        Task<IEnumerable<IIdentityError>> SetLockoutEnabledAsync(IApplicationUser user, bool enabled);
        Task<IEnumerable<IIdentityError>> SetLockoutEndDateAsync(IApplicationUser user, DateTimeOffset? lockoutEnd);
        Task<IEnumerable<IIdentityError>> SetPhoneNumberAsync(IApplicationUser user, string phoneNumber);
        Task<IEnumerable<IIdentityError>> SetTwoFactorEnabledAsync(IApplicationUser user, bool enabled);
        Task<IEnumerable<IIdentityError>> SeIApplicationUserNameAsync(IApplicationUser user, string userName);
        Task<IEnumerable<IIdentityError>> UpdateAsync(IApplicationUser user);
        Task UpdateNormalizedEmailAsync(IApplicationUser user);
        Task UpdateNormalizedUserNameAsync(IApplicationUser user);
        //Task<IEnumerable<IIdentityError>> UpdateSecurityStampAsync(IApplicationUser user);
        Task<bool> VerifyChangePhoneNumberTokenAsync(IApplicationUser user, string token, string phoneNumber);
        Task<bool> VerifyTwoFactorTokenAsync(IApplicationUser user, string tokenProvider, string token);
        Task<bool> VerifyUserTokenAsync(IApplicationUser user, string tokenProvider, string purpose, string token);
        string CreateTwoFactorRecoveryCode();
        void Dispose(bool disposing);
    }

    public interface IApplicationUser
    {
        DateTimeOffset? LockoutEnd { get; set; }
        bool TwoFactorEnabled { get; set; }
        bool PhoneNumberConfirmed { get; set; }
        string PhoneNumber { get; set; }
        string ConcurrencyStamp { get; set; }
        string SecurityStamp { get; set; }
        string PasswordHash { get; set; }
        bool EmailConfirmed { get; set; }
        string NormalizedEmail { get; set; }
        string Email { get; set; }
        string NormalizedUserName { get; set; }
        string UserName { get; set; }
        string Id { get; set; }
        bool LockoutEnabled { get; set; }
        int AccessFailedCount { get; set; }
    }
    public interface IIdentityError
    {
        string Code { get; set; }
        string Description { get; set; }
    }
}
