using System;
using System.Collections.Generic;

namespace MinSetupCore.Models
{
    public class Entity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateDeleted { get; set; }
    }

    public class Dish : Entity
    {
        public string Name { get; set; }

        public string Pic
        {
            get
            {
                return Name is null ? null : (Name.Replace(" ", "").Replace("'", "")).ToLower() + ".jpg";
            }
        }
    }

    public class Chef : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public Country Country { get; set; }
    }

    public class Country : Entity
    {
        public string Name { get; set; }
    }

    public class Category : Entity
    {
        public string Name { get; set; }
    }

    public class Meal : Entity
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageName { get { return Name.Replace(" ", "_").ToLower() + ".jpg"; } }

        public int? CategoryId { get { return Category.Id; } }
    }

    public class ChatMessage : Entity
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }
    }

    public class Dinner : Entity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Chef Chef { get; set; }
        public Country Country { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public Meal BonusMeal { get; set; }
        public string Comments { get; set; }
        public bool Organic { get; set; }
    }

    public class Lunch : Entity
    {
        public string Person { get; set; }
        public Dish Dish { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public Country Country { get; set; }
        public Chef Chef { get; set; }
        public bool Organic { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public int MealsCount => Meals.Count();
    }

    public class Message : Entity
    {
        public string From { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime DateReceived { get; set; }

        public bool IsRead { get; set; }
    }

    public class Spreadsheet : Entity
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public string Meal { get; set; }
    }

    public class Restaurant : Entity
    {
        public string Name { get; set; }

        public bool IsCreated { get; set; }
    }

    public class RestaurantAddress : Entity
    {
        public int RestaurantId { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public Chef Chef { get; set; }
    }

    public class TreeNode : Entity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public TreeNode Parent { get; set; }

        public int? ParentId { get { return Parent?.Id; } }
    }

    public class Meeting : Entity
    {
        public string Title { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Location { get; set; }

        public string Color { get; set; }

        public string Notes { get; set; }

        public bool AllDay { get; set; }
    }

    public class Organisation
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class ParentMeal : Entity
    {
        public ICollection<Category> Categories { get; set; }

        public Meal Meal { get; set; }

        public ICollection<Meal> Meals1 { get; set; }
    }

    public class Order : Entity
    {
        public string Customer { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public Country Country { get; set; }

        public int Discount { get; set; }

        public DateTime Date { get; set; }

        public bool Delivered { get; set; }
    }

    public enum WeatherType
    {
        Sunny = 1,
        Cloudy = 2,
        Foggy = 3,
        Windy = 4,
        ScottishSummer = 5
    }
}