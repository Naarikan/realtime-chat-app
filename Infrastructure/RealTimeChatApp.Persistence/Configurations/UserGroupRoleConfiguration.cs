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
			// UserId ve GroupChatId bileşen anahtarı
			builder.HasKey(x => new { x.UserId, x.GroupChatId });

			// Kullanıcı ile ilişki
			builder.HasOne(u => u.User)
				.WithMany(u => u.UsersGroupRoles)
				.HasForeignKey(u => u.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			// Rol ile ilişki
			builder.HasOne(r => r.Role)
				.WithMany(r => r.UsersGroupRoles)
				.HasForeignKey(r => r.RoleId) // RoleId artık anahtar değil
				.OnDelete(DeleteBehavior.Restrict); // Silme davranışını ayarlayın

			// Grup Sohbeti ile ilişki
			builder.HasOne(gc => gc.GroupChat)
				.WithMany(gc => gc.UsersGroupRoles)
				.HasForeignKey(gc => gc.GroupChatId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}

}
