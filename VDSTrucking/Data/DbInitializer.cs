using System;
using System.Linq;
using VDSTrucking.Models;

namespace VDSTrucking.Data
{
    public static class DbInitializer
    {
        public static void Initialize(VDSDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Trucks.Any())
            {
                return;   // DB has been seeded
            }

            var trucks = new Truck[]
            {
                new Truck{Name="Truck 436"},
                new Truck{Name="Truck 486"},
                new Truck{Name="Truck AFA 7189"}
            };

            foreach (Truck item in trucks)
            {
                context.Trucks.Add(item);
            }
            context.SaveChanges();

            var drivers = new Driver[]
            {
                new Driver{ FirstName="Michael", LastName="LastName", MiddleName="MiddleName"},
                new Driver{ FirstName="Gilbert", LastName="LastName", MiddleName="MiddleName"},
                new Driver{ FirstName="Aldrien", LastName="LastName", MiddleName="MiddleName"},
                new Driver{ FirstName="Oscar", LastName="LastName", MiddleName="MiddleName"}
            };

            foreach (Driver item in drivers)
            {
                context.Drivers.Add(item);
            }
            context.SaveChanges();

            var helpers = new Helper[]
            {
                new Helper{ FirstName="Nikko", LastName="LastName", MiddleName="MiddleName"},
                new Helper{ FirstName="Aldwin", LastName="LastName", MiddleName="MiddleName"},
                new Helper{ FirstName="Rex", LastName="LastName", MiddleName="MiddleName"},
                new Helper{ FirstName="Oscar", LastName="LastName", MiddleName="MiddleName"},
                new Helper{ FirstName="Demetrio", LastName="LastName", MiddleName="MiddleName"},
                new Helper{ FirstName="Alfonso", LastName="LastName", MiddleName="MiddleName"},
                new Helper{ FirstName="Crispin", LastName="LastName", MiddleName="MiddleName"}
            };

            foreach (Helper item in helpers)
            {
                context.Helpers.Add(item);
            }
            context.SaveChanges();

            var locations = new Location[]
            {
                new Location{ Name="Quezon City"},
                new Location{ Name="Caloocan"},
                new Location{ Name="Malabon"},
                new Location{ Name="Navotas"},
                new Location{ Name="Valenzuela"},
                new Location{ Name="San Juan"},
                new Location{ Name="Pasig"},
                new Location{ Name="Marikina"},
                new Location{ Name="Mandaluyong"},
                new Location{ Name="Makati"},
                new Location{ Name="Taguig"},
                new Location{ Name="Pateros"},
                new Location{ Name="Pasay"},
                new Location{ Name="Manila"},
                new Location{ Name="Paranaque"},
                new Location{ Name="Las Pinas"},
                new Location{ Name="Muntinlupa"},
                new Location{ Name="San Jose Del Monte"},
                new Location{ Name="Sta. Maria"},
                new Location{ Name="Meycauayan"},
                new Location{ Name="Plaridel"},
                new Location{ Name="Malolos"},
                new Location{ Name="Baliuag"},
                new Location{ Name="San Miguel"},
                new Location{ Name="Bacoor"},
                new Location{ Name="Imus"},
                new Location{ Name="Cavite"},
                new Location{ Name="Dasmarinas"},
                new Location{ Name="Rosario"},
                new Location{ Name="Carmona"},
                new Location{ Name="Tagaytay"},
                new Location{ Name="San Fernando, Pampanga"},
                new Location{ Name="Mabalacat, Pampanga"},
                new Location{ Name="Angeles, Pampanga"},
                new Location{ Name="Lubao, Pampanga"},
                new Location{ Name="Subic, Zambales"},
                new Location{ Name="Masinloc, Zambales"},
                new Location{ Name="Candelaria, Zambales"},
                new Location{ Name="Sta. Cruz, Zambales"},
                new Location{ Name="Dinalupihan"},
                new Location{ Name="Balanga"},
                new Location{ Name="Mariveles"},
                new Location{ Name="Virac"},
                new Location{ Name="Sorsogon"},
                new Location{ Name="Yamang Bukid - Naga"},
                new Location{ Name="Yamang Bukid - Baguio"}
            };

            foreach (Location item in locations)
            {
                context.Locations.Add(item);
            }
            context.SaveChanges();

            var routes = new Route[]
            {
                new Route{ Location=locations[0], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[1], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[2], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[3], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[4], Rate=3000, DriverRate=450, HelperRate=350}, // Valenzuela
                new Route{ Location=locations[5], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[6], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[7], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[8], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[9], Rate=3000, DriverRate=450, HelperRate=350}, // Makati
                new Route{ Location=locations[10], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[11], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[12], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[13], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[14], Rate=3500, DriverRate=450, HelperRate=350}, // Paranaque
                new Route{ Location=locations[15], Rate=3500, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[16], Rate=3500, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[17], Rate=3000, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[18], Rate=3500, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[19], Rate=3500, DriverRate=450, HelperRate=350}, // Meycauayan
                new Route{ Location=locations[20], Rate=4500, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[21], Rate=4500, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[22], Rate=5300, DriverRate=530, HelperRate=400},
                new Route{ Location=locations[23], Rate=5800, DriverRate=580, HelperRate=400},
                new Route{ Location=locations[24], Rate=4000, DriverRate=450, HelperRate=350}, // Bacoor
                new Route{ Location=locations[25], Rate=4200, DriverRate=450, HelperRate=350},
                new Route{ Location=locations[26], Rate=4800, DriverRate=480, HelperRate=350},
                new Route{ Location=locations[27], Rate=4800, DriverRate=480, HelperRate=350},
                new Route{ Location=locations[28], Rate=4700, DriverRate=470, HelperRate=350},
                new Route{ Location=locations[29], Rate=5300, DriverRate=530, HelperRate=400}, // Carmona
                new Route{ Location=locations[30], Rate=6300, DriverRate=630, HelperRate=400},
                new Route{ Location=locations[31], Rate=5000, DriverRate=500, HelperRate=400},
                new Route{ Location=locations[32], Rate=5800, DriverRate=580, HelperRate=400},
                new Route{ Location=locations[33], Rate=5800, DriverRate=580, HelperRate=400},
                new Route{ Location=locations[34], Rate=6300, DriverRate=630, HelperRate=400}, // Lubao, Pampanga
                new Route{ Location=locations[35], Rate=7000, DriverRate=700, HelperRate=400},
                new Route{ Location=locations[36], Rate=9000, DriverRate=900, HelperRate=400},
                new Route{ Location=locations[37], Rate=10000, DriverRate=1000, HelperRate=400},
                new Route{ Location=locations[38], Rate=12000, DriverRate=1200, HelperRate=400},
                new Route{ Location=locations[39], Rate=6000, DriverRate=600, HelperRate=400}, // Dinalupihan 
                new Route{ Location=locations[39], Rate=6500, DriverRate=650, HelperRate=400},
                new Route{ Location=locations[39], Rate=7000, DriverRate=700, HelperRate=400},
                new Route{ Location=locations[39], Rate=28000, DriverRate=2800, HelperRate=1500},
                new Route{ Location=locations[39], Rate=25000, DriverRate=2500, HelperRate=1500},
                new Route{ Location=locations[39], Rate=18000, DriverRate=1800, HelperRate=800}, // Yamang Bukid - Naga
                new Route{ Location=locations[40], Rate=10000, DriverRate=1000, HelperRate=500}
            };

            //var courses = new Course[]
            //{
            //new Course{CourseID=1050,Title="Chemistry",Credits=3},
            //new Course{CourseID=4022,Title="Microeconomics",Credits=3},
            //new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
            //new Course{CourseID=1045,Title="Calculus",Credits=4},
            //new Course{CourseID=3141,Title="Trigonometry",Credits=4},
            //new Course{CourseID=2021,Title="Composition",Credits=3},
            //new Course{CourseID=2042,Title="Literature",Credits=4}
            //};
            //foreach (Course c in courses)
            //{
            //    context.Courses.Add(c);
            //}
            //context.SaveChanges();

            //var enrollments = new Enrollment[]
            //{
            //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            //new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            //new Enrollment{StudentID=3,CourseID=1050},
            //new Enrollment{StudentID=4,CourseID=1050},
            //new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            //new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            //new Enrollment{StudentID=6,CourseID=1045},
            //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            //};
            //foreach (Enrollment e in enrollments)
            //{
            //    context.Enrollments.Add(e);
            //}
        }
    }
}
