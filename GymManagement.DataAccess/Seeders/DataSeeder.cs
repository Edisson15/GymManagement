using GymManagement.Domain.Entities;
using GymManagement.Domain.Enums;
using GymManagement.DataAccess.Context;

namespace GymManagement.DataAccess.Seeders
{
    public static class DataSeeder
    {
        public static void Seed(GymDbContext context)
        {
            context.Database.EnsureCreated();

            // MEMBERSHIPS
            if (!context.Memberships.Any())
            {
                var memberships = new List<Membership>
                {
                    new Membership
                    {
                        Name = "Basic",
                        Price = 50,
                        Type = MembershipType.Basic
                    },
                    new Membership
                    {
                        Name = "Premium",
                        Price = 100,
                        Type = MembershipType.Premium
                    },
                    new Membership
                    {
                        Name = "VIP",
                        Price = 150,
                        Type = MembershipType.VIP 
                    }
                };

                context.Memberships.AddRange(memberships);
                context.SaveChanges();
            }

            // TRAINERS
            if (!context.Trainers.Any())
            {
                var trainers = new List<Trainer>
                {
                    new Trainer
                    {
                        Name = "Carlos Perez",
                        Specialty = "Crossfit"
                    },
                    new Trainer
                    {
                        Name = "Laura Gomez",
                        Specialty = "Yoga"
                    }
                };

                context.Trainers.AddRange(trainers);
                context.SaveChanges();
            }

            // GYM CLASSES
            if (!context.GymClasses.Any())
            {
                var trainer = context.Trainers.First();

                var classes = new List<GymClass>
                {
                    new GymClass
                    {
                        Name = "Morning Crossfit",
                        TrainerId = trainer.Id,
                        Schedule = DateTime.Now.AddDays(1),
                        Capacity = 20,
                        Status = ClassStatus.Scheduled
                    },
                    new GymClass
                    {
                        Name = "Evening Yoga",
                        TrainerId = trainer.Id,
                        Schedule = DateTime.Now.AddDays(2),
                        Capacity = 15,
                        Status = ClassStatus.Scheduled
                    }
                };

                context.GymClasses.AddRange(classes);
                context.SaveChanges();
            }

            // MEMBERS
            if (!context.Members.Any())
            {
                var membership = context.Memberships.First();

                var members = new List<Member>
                {
                    new Member
                    {
                        Name = "Juan",
                        Email = "juan@test.com",
                        MembershipId = membership.Id
                    },
                    new Member
                    {
                        Name = "Maria",
                        Email = "maria@test.com",
                        MembershipId = membership.Id
                    }
                };

                context.Members.AddRange(members);
                context.SaveChanges();
            }
        }
    }
}