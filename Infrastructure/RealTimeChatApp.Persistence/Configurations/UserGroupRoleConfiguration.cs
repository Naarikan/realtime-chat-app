using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Persistence.Configurations
{
    public class UserGroupRoleConfiguration : IEntityTypeConfiguration<UserGroupRole>
    {
        public void Configure(EntityTypeBuilder<UserGroupRole> builder)
        {
            builder.HasKey(x =>new {x.UserId,x.RoleId,x.GroupChatId });

            builder.HasOne(u => u.User)
                .WithMany(u => u.UsersGroupRoles)//-->burada bireçok ilişkili lduğu entityleri bulup ona göre işlem yapıyor kendisi üzerinde 
                                                 //tam olarak işlem yapmaz
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Role)
                .WithMany(r=>r.UsersGroupRoles)
                .HasForeignKey(r=>r.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gc => gc.GroupChat)
                .WithMany(gc => gc.UsersGroupRoles)
                .HasForeignKey(gc => gc.GroupChatId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
