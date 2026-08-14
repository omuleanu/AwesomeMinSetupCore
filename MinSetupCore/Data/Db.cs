using MinSetupCore.Models;
using System.Collections.Concurrent;

namespace MinSetupCore.Data
{
    public static class Db
    {
        public static IList<Lunch> Lunches = new List<Lunch>();
        public static IList<Country> Countries = new List<Country>();
        public static IList<Chef> Chefs = new List<Chef>();
        public static IList<Meal> Meals = new List<Meal>();
        public static IList<Dish> Dishes = new List<Dish>();
        public static IList<Category> Categories = new List<Category>();
        public static IList<Organisation> Organisations = new List<Organisation>();
        public static IList<Order> Orders = new List<Order>();

        public static IList<Meal> Meals1 { get { return Meals.Where(o => o.Category == Categories.First()).ToList(); } }

        public static IEnumerable<ChatMessage> ChatMessages => chatMessages.Values.Where(o => !o.IsDeleted);
        public static IEnumerable<Dinner> Dinners => dinners.Values.Where(o => !o.IsDeleted);
        public static IEnumerable<ParentMeal> ParentMeals => parentMeals.Values.Where(o => !o.IsDeleted);
        public static IEnumerable<Message> Messages => messages.Values.Where(o => !o.IsDeleted);
        public static IEnumerable<Restaurant> Restaurants => restaurants.Values.Where(o => !o.IsDeleted);
        public static IEnumerable<RestaurantAddress> RestaurantAddresses => restaurantAddresses.Values.Where(o => !o.IsDeleted);
        public static IEnumerable<TreeNode> TreeNodes => treeNodes.Values.Where(o => !o.IsDeleted);
        public static IEnumerable<Spreadsheet> Spreadsheets => spreadsheets.Values.Where(o => !o.IsDeleted);
        public static IEnumerable<Meeting> Meetings => meetings.Values.Where(o => !o.IsDeleted);

        private static readonly ConcurrentDictionary<int, ChatMessage> chatMessages = new ConcurrentDictionary<int, ChatMessage>();
        private static readonly ConcurrentDictionary<int, Dinner> dinners = new ConcurrentDictionary<int, Dinner>();
        private static readonly ConcurrentDictionary<int, ParentMeal> parentMeals = new ConcurrentDictionary<int, ParentMeal>();
        private static readonly ConcurrentDictionary<int, Message> messages = new ConcurrentDictionary<int, Message>();
        private static readonly ConcurrentDictionary<int, Spreadsheet> spreadsheets = new ConcurrentDictionary<int, Spreadsheet>();
        private static readonly ConcurrentDictionary<int, Restaurant> restaurants = new ConcurrentDictionary<int, Restaurant>();
        private static readonly ConcurrentDictionary<int, RestaurantAddress> restaurantAddresses = new ConcurrentDictionary<int, RestaurantAddress>();
        private static readonly ConcurrentDictionary<int, TreeNode> treeNodes = new ConcurrentDictionary<int, TreeNode>();
        private static readonly ConcurrentDictionary<int, Meeting> meetings = new ConcurrentDictionary<int, Meeting>();

        private static int gid = 151;

        public static int NewId()
        {
            lock (lockObj)
            {
                return gid += 2;
            }
        }

        private static readonly object lockObj = new object();

        public static T Add<T>(T ent) where T : Entity
        {
            lock (lockObj)
            {
                ent.Id = gid += 2;
            }

            ent.DateCreated = DateTime.UtcNow;

            var dict = (ConcurrentDictionary<int, T>)Dict<T>();

            if (dict != null)
            {
                if (dict.TryAdd(ent.Id, ent))
                {
                    return ent;
                }
            }

            var list = (List<T>)List(typeof(T));

            if (list != null)
            {
                addToList(ent);
                return ent;
            }

            throw new Exception("can not add new item");
        }

        public static T Find<T>(int? id) where T : Entity
        {
            return Get<T>(id.Value);
        }

        public static T Get<T>(int? id) where T : Entity
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            return Get<T>(id.Value);
        }

        public static Task<T> GetAsync<T>(int? id) where T : Entity
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            return Task.Run(() => Get<T>(id.Value));
        }

        public static T Get<T>(int id) where T : Entity
        {
            T entity;
            var list = List<T>();
            if (list != null)
            {
                entity = ((IList<T>)list).SingleOrDefault(o => o.Id == id);
            }
            else
            {
                var dict = (ConcurrentDictionary<int, T>)Dict<T>();
                dict.TryGetValue(id, out entity);
            }

            if (entity == null || entity.IsDeleted) throw new EntityMissingException("this item doesn't exist anymore");
            return entity;
        }

        public static IEnumerable<T> Set<T>() where T : Entity
        {
            IEnumerable<T> set;
            var list = List<T>();
            if (list != null)
            {
                set = (IList<T>)list;
            }
            else
            {
                var dict = (ConcurrentDictionary<int, T>)Dict<T>();
                set = dict.Values;
            }

            return set;
        }

        public static void Remove<T>(T entity) where T : Entity
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Delete<T>(entity.Id);
        }

        public static void Delete<T>(int id) where T : Entity
        {
            if (Set<T>().Count(o => !o.IsDeleted) < 10)
            {
                RestoreItems();
            }

            var ent = Get<T>(id);
            ent.DateDeleted = DateTime.UtcNow;
            ent.IsDeleted = true;
        }

        public static void RestoreItems()
        {
            Action<IEnumerable<Entity>> restore = entities =>
            {
                foreach (var o in entities)
                {
                    if (o.IsDeleted)
                    {
                        o.IsDeleted = false;
                    }
                }
            };

            restore(dinners.Values);
            restore(messages.Values);
            restore(meetings.Values);
            restore(restaurants.Values);
            restore(restaurantAddresses.Values);
            restore(spreadsheets.Values);
            restore(treeNodes.Values);
            restore(meetings.Values);
        }

        private static object List<T>()
        {
            return List(typeof(T));
        }

        private static object List(Type type)
        {
            if (type == typeof(Lunch)) return Lunches;
            if (type == typeof(Country)) return Countries;
            if (type == typeof(Chef)) return Chefs;
            if (type == typeof(Meal)) return Meals;
            if (type == typeof(Dish)) return Dishes;
            if (type == typeof(Category)) return Categories;
            if (type == typeof(Order)) return Orders;

            return null;
        }

        private static object Dict<TEntity>() where TEntity : Entity
        {
            var type = typeof(TEntity);

            if (type == typeof(ChatMessage)) return chatMessages;
            if (type == typeof(Dinner)) return dinners;
            if (type == typeof(ParentMeal)) return parentMeals;
            if (type == typeof(Message)) return messages;
            if (type == typeof(Spreadsheet)) return spreadsheets;
            if (type == typeof(Restaurant)) return restaurants;
            if (type == typeof(RestaurantAddress)) return restaurantAddresses;
            if (type == typeof(TreeNode)) return treeNodes;
            if (type == typeof(Meeting)) return meetings;

            return null;
        }

        private static void addToList<T>(T o) where T : Entity
        {
            o.DateCreated = DateTime.UtcNow;
            o.Id = gid += 2;
            var list = (IList<T>)List<T>();
            list.Add(o);
        }

        internal static void AddRange<T>(IEnumerable<T> items) where T : Entity
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}