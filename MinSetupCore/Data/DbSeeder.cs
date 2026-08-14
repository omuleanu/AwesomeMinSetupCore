using MinSetupCore.Models;

namespace MinSetupCore.Data
{
    public class DbSeeder
    {
        public void Seed(bool recreate = false)
        {
            #region init

            if (Db.Meals.Any()) return;
            #endregion

            #region arrays
            var CountryNames = new[]
            {
                "Elwynn Forest", "Stormwind", "Loch Modan", "Westfall",
                "Feralas", "Kitej", "Winterspring", "Teldrassil",
                "La Croisette", "Goldshire", "Sylvanaar", "Redridge Mountains", "Stone Cutter",
                "Regent", "Piccadilly", "Hatton Garden", "Greville", "Farringdon", "Islington",
                "Carpana", "Jisina", "Ghidrimesti", "Kebnekaise", "Kullaberg",
                "Magrathea", "Ursa Minor Beta", "Betelgeuse", "Milliways"
            };

            var PersonNames = new[]
            {
                "Aaron", "James", "Jeremy", "Richard", "Tommy", "Alan", "Charlie", "Jake", "Penny", "Sheldon", "Leonard", "Zazzles", "Howard", "Rajesh",
                "Phil", "Scott", "Bernadette", "Russell", "Timmy", "Jeff", "Adam", "Jennifer", "Audrey", "Claudia", "Brenda", "Tracy", "Alice", "Pierre",
                "Ryu", "Ken", "Irene", "Henry", "Lucas", "Maurice", "Luke", "Matt", "Trey", "David", "Patrick", "Hugo", "Sam", "Sebastian", "Ben", "Robert",
                "Oliver", "Justin", "Jamie", "Mateo", "Cheyenne", "Marcus", "Garrett", "Jonah", "Kelly", "Amy", "Glenn", "Dina", "Gabrielle", "Michelle",
                "Jason", "Joshua", "Benjamin", "Gordon", "Morgan", "Harry", "Daniel", "Jacob", "Sophie", "Emily", "Jessica", "Ella", "Tina", "Emma", "Megan",
                "Caitlin", "Amber", "Fernando", "Evelyn", "Lauren", "Nicole", "Paige", "Eve", "Iris", "Gracie", "Sarah", "Holly", "Elizabeth", "Rachel",
                "Courtney", "Owen", "Ruby", "Peter", "Michael", "Samir", "Joanna", "Stan", "Milton", "Tom", "Jerry", "William", "Carter", "Dolores", "Earl",
                "Francesco", "Mario", "Luigi", "Vincenzo", "Sylvain", "Nathan", "John", "Mary", "Maria", "Helena", "Linda", "Lucy", "Sergio", "Hillary",
                "Erlich", "Gavin", "Monica", "Mia", "Pedro", "Paul", "Ford", "Zaphod", "Marvin", "Arthur", "Trillian", "Slartibartfast", "Lallafa",
                "Nils", "Martin"
            };

            var locations = new[] { "Home", "University", "Restaurant", "Visit", "Diner", "Central Perk", "Tavern" };

            var chefNames = new[]
                {
                new [] {"Naked", "Chef"},
                new [] {"Chef", "Chef"},
                new [] {"Bruce", "Nolan"},
                new [] {"Omu", "Man"},
                new [] {"Pepper", "Tomato"},
                new [] {"Charles", "Duchemin"},
                new [] {"Cheyenne", "Goldblum"},
                new [] {"Phoebe", "Phoebes"},
                new [] {"Casse", "Croute"},
                new [] {"Fromage", "Sandwich"},
                new [] {"Josh", "Baskin"},
                new [] {"Hercules", "Oat"},
                new [] {"Joanna", "Stan"},
                new [] {"Peter", "Gibbons"},
                new [] {"Tom", "Smykowski"},
                new [] {"Demeter", "Harvest"},
                new [] {"Hyperion", "Light"},
                new [] {"Gaia", "Earth"},
                new [] {"Chronos", "Timpus"},
                new [] {"Manuel", "Calavera"},
                new [] {"Ford", "Prefect"},
                new [] {"Zane", "Zaminsky"},
            };

            var dinnerNames = new[] {"hot chocolate", "believe in miracles", "out and about", "dinner tonight", "watch tv", "last night",
                "toasty", "great", "coffee for me", "dinner with friends", "school lunch",
                "eating at the pub", "cooking in the garden", "ninja dinner", "broccoli power", "eating out", "Awesome dinner",
                "Uber dinner", "Fruity dish", "Nice dish", "Nerds eating", "Pros eating", "Morning Coffee", "Muffin",
                "Picnic", "Dejeuner", "Breakfast", "petit dej", "Apero",
                "Snacks and movie", "Morning meal", "Morning Tea", "Cookies", "Apples", "Salad"};

            var dishNames = new[] {"Banana", "Cheesecake", "Hot Beverage", "Apple", "Oat meal", "French toast", "Pizza", "Apple Pie", "Shepherd's pie",
            "Big Salad", "Soup"};

            var restaurantNames = new[] { "McDowell's", "Chotchkie's", "Chili's", "Flingers", "The Cheesecake Factory", "The Rolling Donut", "Big Kahuna Burger", "City Wok", "Cluckin' Bell",
                "Central Perk", "Island Diner", "Dream Cafe", "Cleveland's Deli", "Don't Drop Inn", "The Happy Sumo", "The Hungry Hun", "Krusty Burger", "Luigi's",
                "Big T Burgers and Fries", "Pizza on a stick" };

            var colors = new[] { "#5484ED", "#A4BDFC", "#7AE7BF", "#51B749", "#FBD75B", "#FFB878", "#FF887C", "#DC2127", "#DBADFF", "#E1E1E1" };
            #endregion



            #region Dishes
            foreach (var dishName in dishNames)
            {
                add(new Dish { Name = dishName });
            }

            #endregion

            add(new ChatMessage { Content = "hi", DateCreated = DateTime.UtcNow, UserName = "awe" });

            #region Categories
            var categoriesNames = new[] { "Fruits", "Vegetables", "Nuts", "Grains", "Legumes" };
            foreach (var category in categoriesNames)
            {
                add(new Category { Name = category });
            }
            #endregion

            #region Meals        
            var Categories = Db.Set<Category>().ToArray();
            var legumesCat = Categories.First(c => c.Name == "Legumes");
            var grainsCat = Categories.First(c => c.Name == "Grains");
            var vegetablesCat = Categories.First(c => c.Name == "Vegetables");
            var fruitsCat = Categories.First(c => c.Name == "Fruits");
            var nutsCat = Categories.First(c => c.Name == "Nuts");


            add(new Meal { Name = "Mango", Category = fruitsCat, Description = "The mango is a fleshy stone fruit belonging to the genus Mangifera" });
            add(new Meal { Name = "Apple", Category = fruitsCat, Description = "The apple is the pomaceous fruit of the apple tree" });
            add(new Meal { Name = "Papaya", Category = fruitsCat, Description = "The papaya is a large tree-like plant, with a single stem growing from 5 to 10 metres" });
            add(new Meal { Name = "Banana", Category = fruitsCat, Description = "Bananas come in a variety of sizes and colors when ripe, including yellow, purple, and red." });
            add(new Meal { Name = "Cherry", Category = fruitsCat, Description = "The cherry is the fruit of many plants of the genus Prunus, and is a fleshy stone fruit" });

            add(new Meal { Name = "Tomato", Category = vegetablesCat, Description = "The tomato fruit is consumed in diverse ways, including raw, as an ingredient in many dishes and sauces" });
            add(new Meal { Name = "Potato", Category = vegetablesCat, Description = "A potato is a starchy edible tuber native to South America and cultivated all over the world" });
            add(new Meal { Name = "Cucumber", Category = vegetablesCat, Description = "Like the tomato, the cucumber is a fruit. Botanically speaking, a fruit is the mature ovary of a flowering plant" });
            add(new Meal { Name = "Onion", Category = vegetablesCat, Description = " It is possible to chop the greens into small pieces for salads and as a garnish" });
            add(new Meal { Name = "Carrot", Category = vegetablesCat, Description = "The rich orange color of carrots comes from beta carotene, which also happens to be very good for optical health" });

            add(new Meal { Name = "Celery", Category = vegetablesCat, Description = "Although originally cultivated for its perceived medicinal qualities, celery has since made the jump into the daily diets" });
            add(new Meal { Name = "Broccoli", Category = vegetablesCat, Description = "Sometimes broccoli is compared to tiny trees" });
            add(new Meal { Name = "Artichoke", Category = vegetablesCat, Description = "The globe artichoke enjoys a long history of both lore and cooking preparation" });
            add(new Meal { Name = "Cauliflower", Category = vegetablesCat, Description = "As a general rule, the head is white, but variants of cauliflower come in purple and green as well" });
            add(new Meal { Name = "Lettuce", Category = vegetablesCat, Description = "Leaf lettuce is often very lightweight and ruffly, with a wrinkly surface and a soft, almost velvety texture" });

            add(new Meal { Name = "Hazelnuts", Category = nutsCat, Description = "Hazelnuts are produced by hazel trees" });
            add(new Meal { Name = "Chestnuts", Category = nutsCat, Description = "They have creamy white sweet flesh which appears in a number of cuisines" });
            add(new Meal { Name = "Walnuts", Category = nutsCat, Description = "A walnut is a seed from a tree in the genus Juglans" });
            add(new Meal { Name = "Almonds", Category = nutsCat, Description = "Almonds come in two varieties, sweet and bitter" });
            add(new Meal { Name = "Mongongo", Category = nutsCat, Description = "In addition to producing a highly useful lightweight, durable wood, the mongongo tree also yields a distinctive fruit" });

            add(new Meal { Name = "Rice", Category = grainsCat, Description = "Rice is a keystone of the grass family that produces a vast number of grains " });
            add(new Meal { Name = "Wheat", Category = grainsCat, Description = "Wheat is a type of grass grown all over the world for its highly nutritious and useful grain." });
            add(new Meal { Name = "Buckwheat", Category = grainsCat, Description = "Despite the name, buckwheat is not related to wheat" });
            add(new Meal { Name = "Millet", Category = grainsCat, Description = "Millet is a cereal grain, a grass widely grown for its edible seeds." });
            add(new Meal { Name = "Barley", Category = grainsCat, Description = " a source of fermentable material for beer and certain distilled beverages, and as a component of various health foods" });

            add(new Meal { Name = "Red Lentils", Category = legumesCat, Description = "Red lentils are quick-cooking legumes, rich in protein and fiber, often used in soups and stews." });
            add(new Meal { Name = "Chickpeas", Category = legumesCat, Description = "Chickpeas, also known as garbanzo beans, are versatile legumes used in hummus, curries, and salads." });
            add(new Meal { Name = "Cannellini Beans", Category = legumesCat, Description = "Cannellini beans are popular in Italian cuisine, packed with protein and fiber." });
            add(new Meal { Name = "Green Peas", Category = legumesCat, Description = "Green peas are sweet legumes eaten fresh or dried, often used in soups, side dishes, and purees." });
            add(new Meal { Name = "Kidney Beans", Category = legumesCat, Description = "Kidney beans are large, red legumes commonly used in chili and stews, known for their hearty texture." });



            #endregion

            #region ParentMeals


            var categories = Db.Categories.ToArray();
            var meals = Db.Meals.ToArray();

            for (int i = 0; i < 50; i++)
            {
                var categs = Shuffle(categories, rnd.Next(1, 4));
                var cids = categs.Select(o => o.Id);
                var catmeals = meals.Where(m => cids.Contains(m.Category.Id)).ToArray();

                add(new ParentMeal { Categories = categs, Meal = Rnd(catmeals), Meals1 = Shuffle(catmeals, 3) });
            }



            #endregion

            #region Countries
            foreach (var country in CountryNames)
            {
                add(new Country { Name = country });
            }


            #endregion

            #region Chefs
            var Meals = Db.Meals.ToArray();
            var Countries = Db.Countries.ToArray();

            foreach (var nms in chefNames)
            {
                add(new Chef { FirstName = nms[0], LastName = nms[1], Country = Rnd(Countries) });
            }


            #endregion

            #region Dinners
            var Chefs = Db.Chefs.ToArray();
            var Dishes = Db.Dishes.ToArray();

            foreach (var dish in dishNames)
            {
                AddDinner(dish);
            }

            foreach (var o in dinnerNames)
            {
                AddDinner(o);
            }


            #endregion

            #region Lunches
            IDictionary<string, List<Dish>> personDish = PersonNames.ToDictionary(o => o, o => new List<Dish>());
            IDictionary<string, int> personTimes = PersonNames.ToDictionary(o => o, o => 0);
            var prices = new[] { 10, 20, 30, 50, 70, 23, 45, 100, 21, 79, 39, 18 };
            List<Lunch> lunches = new List<Lunch>();

            var lunchesCount = 750;
            for (var i = 0; i < lunchesCount; i++)
            {
                var maxLunches = lunchesCount / PersonNames.Length;
                var pplc = lunchesCount / PersonNames.Length;

                var person = Rnd(PersonNames);
                if (lunches.Count(o => o.Person == person) >= pplc) person = Rnd(PersonNames);

                if (personTimes[person] >= maxLunches)
                {
                    person = Rnd(PersonNames);
                }

                personTimes[person]++;

                Dish dish;

                if (personDish[person].Count == 3)
                {
                    dish = Rnd(personDish[person]);
                }
                else
                {
                    dish = Rnd(Dishes);
                    personDish[person].Add(dish);
                }

                var isOrganic = rnd.Next(10) < 5;

                lunches.Add(new Lunch
                {
                    Date = RndDate(),
                    Dish = dish,
                    Person = person,
                    Location = Rnd(locations),
                    Price = (decimal)(Rnd(prices) * (isOrganic ? 1.5 : 1)),
                    Country = Rnd(Countries),
                    Chef = Rnd(Chefs),
                    Organic = isOrganic,
                    Meals = RndMeals().ToList()
                });
            }

            Db.AddRange(lunches);

            #endregion

            #region Orders            
            const int OrderCount = 800;
            IDictionary<string, int> customerTimes = PersonNames.ToDictionary(o => o, o => 0);
            IDictionary<string, int> customerTimesUsed = PersonNames.ToDictionary(o => o, o => 0);
            var orderPrices = new[] { 10, 20, 30, 50, 70, 23, 45, 100, 21, 79, 39, 18 };
            List<Order> orders = new List<Order>();

            var maxOrdersPerCustomer = OrderCount / PersonNames.Length;
            var maxOrders = OrderCount / PersonNames.Length;

            for (var i = 0; i < OrderCount; i++)
            {
                var customer = Rnd(PersonNames);
                if (orders.Count(o => o.Customer == customer) >= maxOrdersPerCustomer) customer = Rnd(PersonNames);

                if (customerTimes[customer] >= maxOrders)
                {
                    customer = Rnd(PersonNames);
                }

                customerTimes[customer]++;

                orders.Add(new Order
                {
                    Customer = customer,
                    Quantity = rnd.Next(300),
                    UnitPrice = Rnd(prices),
                    Country = Rnd(Countries),
                    Discount = Rnd(new[] { 0, 10, 20, 30 }),
                    Date = RndDate(DateTime.Now.Year - 2, DateTime.Now.Year),
                    Delivered = rnd.Next(10) < 5
                });
            }

            Db.AddRange(orders);
            #endregion

            #region TreeNodes
            for (int i = 0; i < 15; i++)
            {
                var node = new TreeNode();
                var mealName = Rnd(Meals.Select(o => o.Name).ToList());
                node.Name = $"{mealName} main node";
                node.Price = rnd.Next(30, 150);

                Db.Add(node);

                node.Name += " " + node.Id;

                FillNode(node, 0, rnd.Next(2, 5));
            }

            #endregion

            #region Spreadsheet
            for (int i = 0; i < 20; i++)
            {
                add(new Spreadsheet
                {
                    Name = Rnd(PersonNames),
                    Location = Rnd(CountryNames),
                    Meal = Rnd(Meals).Name
                });
            }

            #endregion

            #region Messages
            for (var i = 0; i < 10; i++)
            {
                add(new Message
                {
                    From = Rnd(PersonNames),
                    Subject = Rnd(dishNames),
                    DateReceived = RndDate(),
                    Body = RndMessage(new[] { PersonNames, dishNames, new[] { "bla bla bla", "and", "or", "it", "for", "something" } }),
                    IsRead = true
                });
            }

            foreach (var message in Db.Messages.OrderByDescending(o => o.DateReceived).Take(5))
            {
                message.IsRead = false;
            }
            #endregion

            #region Restaurants and addresses
            foreach (var restaurantName in restaurantNames.Reverse())
            {
                var restaurant = add(new Restaurant { Name = restaurantName, IsCreated = true });


                add(new RestaurantAddress { RestaurantId = restaurant.Id, Line1 = Rnd(PersonNames) + " square " + rnd.Next(10, 15), Chef = Rnd(Chefs) });
                add(new RestaurantAddress { RestaurantId = restaurant.Id, Line1 = Rnd(PersonNames) + " street " + rnd.Next(10, 35), Chef = Rnd(Chefs) });

            }


            #endregion

            #region Meetings
            var startDate = DateTime.UtcNow.AddDays(-20).Date;
            var endDate = DateTime.UtcNow.AddDays(27);
            var eventDurations = new[] { 15, 20, 30, 45, 60, 120, 450, 30, 15, 45, 60 };
            var lateDurations = new[] { 15, 20, 30, 45, 60, 30, 15 };

            while (startDate < endDate)
            {
                var eventsPerDay = rnd.Next(1, 3);
                if (startDate.DayOfWeek == DayOfWeek.Sunday) eventsPerDay = Math.Min(eventsPerDay, 1);

                for (var i = 0; i < eventsPerDay; i++)
                {
                    var ev = add(new Meeting { Start = startDate, Location = Rnd(locations) });
                    ev.Start = ev.Start.AddHours(rnd.Next(24));

                    if (rnd.Next(50) == 1)
                    {
                        ev.AllDay = true;
                        ev.End = ev.Start;
                    }
                    else
                    {
                        ev.End = ev.Start.AddMinutes(Rnd(ev.Start.Hour > 17 ? lateDurations : eventDurations));
                    }

                    ev.Title = "meeting at " + ev.Location;
                    ev.Color = Rnd(colors);
                }

                startDate = startDate.AddDays(1);
            }


            #endregion

            #region utils
            T add<T>(T item) where T : Entity
            {
                Db.Add(item);

                return item;
            }

            void FillNode(TreeNode parent, int depth, int maxDepth, List<string> usedMealNames = null)
            {
                // Initialize usedMealNames for this depth level if null
                usedMealNames = usedMealNames ?? new List<string>();

                int nodeCount;
                if (depth == 0)
                {
                    nodeCount = Math.Max(rnd.Next(3, 6), 3); // Always at least 3 nodes
                }
                else
                {
                    var maxNodes = (int)Math.Max(5 - depth * 0.7, 1);
                    nodeCount = rnd.Next(1, maxNodes);
                }

                var availableMealNames = Meals.Select(o => o.Name).Where(name => !usedMealNames.Contains(name)).ToList();

                var nodePrices = GetRandomPartition(parent.Price, nodeCount);

                for (int i = 0; i < nodeCount; i++)
                {
                    // If no available meal names left, skip
                    if (!availableMealNames.Any())
                    {
                        continue;
                    }

                    if (depth >= maxDepth || rnd.Next(0, 2) != 1)
                    {
                        var leaf = new TreeNode { Parent = parent };
                        leaf.Name = Rnd(availableMealNames);
                        leaf.Price = nodePrices[i];
                        Db.Add(leaf);
                        usedMealNames.Add(leaf.Name);
                        availableMealNames.Remove(leaf.Name);
                    }
                    else
                    {
                        var node = new TreeNode { Parent = parent };
                        var nodeMealName = Rnd(availableMealNames);
                        node.Name = nodeMealName + " node depth " + depth;
                        node.Price = nodePrices[i];
                        Db.Add(node);
                        usedMealNames.Add(nodeMealName);

                        // Pass the usedMealNames list to child nodes
                        FillNode(node, depth + 1, maxDepth, usedMealNames);
                    }
                }
            }

            decimal[] GetRandomPartition(decimal total, int pcount)
            {
                var breaks = Enumerable.Range(0, pcount - 1)
                    .Select(_ => (decimal)rnd.NextDouble() * total)
                    .OrderBy(x => x)
                    .ToList();

                var result = new decimal[pcount];
                decimal prev = 0;
                for (int i = 0; i < pcount - 1; i++)
                {
                    result[i] = Math.Round(breaks[i] - prev, 2, MidpointRounding.AwayFromZero);
                    prev = breaks[i];
                }

                result[pcount - 1] = Math.Round(total - prev, 2, MidpointRounding.AwayFromZero);

                result[pcount - 1] += total - result.Sum();
                return result;
            }

            void AddDinner(string name)
            {
                if (Db.Dinners.Any(d => d.Name == name)) return;

                add(new Dinner
                {
                    Name = name,
                    Date = RndDate(),
                    Country = Rnd(Countries),
                    Chef = Rnd(Chefs),
                    Meals = RndMeals().ToList(),
                    BonusMeal = Rnd(Meals),
                    Organic = rnd.Next(10) > 3
                });
            }



            IEnumerable<Meal> RndMeals()
            {
                var list = new List<Meal>();
                var x = rnd.Next(1, 4);
                for (var i = 0; i < x; i++)
                {
                    list.Add(Meals[rnd.Next(Meals.Length - 1)]);
                }

                return list.Distinct();
            }
            #endregion

        }

        private static string RndMessage(string[][] ph)
        {
            var s = "Hi \n ";
            for (int i = 0; i < rnd.Next(1000); i++)
            {
                s += " " + Rnd(Rnd(ph));
            }
            return s;
        }

        private static T Rnd<T>(ICollection<T> list)
        {
            return list.ToArray()[rnd.Next(0, list.Count)];
        }

        private static ICollection<T> Shuffle<T>(ICollection<T> source, int takeCount)
        {
            List<T> clone = source.ToList();

            takeCount = Math.Min(takeCount, clone.Count);

            for (int i = 0; i < takeCount; i++)
            {
                // Pick a random index from the remaining pool
                int r = i + rnd.Next(clone.Count - i);

                T temp = clone[r];
                clone[r] = clone[i];
                clone[i] = temp;
            }

            return clone.GetRange(0, takeCount);
        }

        private static DateTime RndDate(int year0 = 2009, int year1 = 2023)
        {
            DateTime start = new DateTime(year0, 1, 1);
            DateTime end = new DateTime(year1, 12, 31);

            int range = (end - start).Days;

            return start.AddDays(rnd.Next(range + 1));
        }

        private static readonly Random rnd = new Random();
    }
}