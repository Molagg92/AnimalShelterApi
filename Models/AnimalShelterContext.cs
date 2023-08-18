using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterApiContext : DbContext
  {
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }

    public AnimalShelterApiContext(DbContextOptions<AnimalShelterApiContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
    builder.Entity<Cat>()
    .HasData(
      new Cat { CatId = 1, Name = "Reina", Breed = "Mutt", Age = 7 },
      new Cat { CatId = 2, Name = "TBone", Breed = "LongHairSomething", Age = 10 },
      new Cat { CatId = 3, Name = "King", Breed = "Bitter", Age = 2 },
      new Cat { CatId = 4, Name = "Macaroni", Breed = "Tabby", Age = 4 },
      new Cat { CatId = 5, Name = "BongWater", Breed = "Hairless", Age = 22 }
       );
      builder.Entity<Dog>()
      .HasData(
        new Dog { DogId = 1, Name = "Matilda", Breed = "Golden Retriever", Age = 7 },
        new Dog { DogId = 2, Name = "Rexie", Breed = "Germain Sheppard", Age = 10 },
        new Dog { DogId = 3, Name = "Matilda", Breed = "Boxer", Age = 2 },
        new Dog { DogId = 4, Name = "Pip", Breed = "Pitt Bull", Age = 4 },
        new Dog { DogId = 5, Name = "Bartholomew", Breed = "Frenchie", Age = 22 }
      );
    }
  }
}