using Forum.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Dal.Configurations
{
	public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			
		}
	}
}
