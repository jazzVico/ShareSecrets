
namespace ShareSecrets.Models
{
    public class ShareSecretsContext : Microsoft.EntityFrameworkCore.DbContext 
    {
        public ShareSecretsContext (Microsoft.EntityFrameworkCore.DbContextOptions<ShareSecretsContext> options)
            : base(options)
        {
        }
        public Microsoft.EntityFrameworkCore.DbSet<ShareSecrets.Models.Secret> Secret { get; set; }
    }
}