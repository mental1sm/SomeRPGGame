using System;
using System.Reflection;

namespace Desert.Combat.Infrastructure;

public class DatabaseManager
{
    private static DatabaseManager _instance;
    private GameContext _context;

    private DatabaseManager()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static DatabaseManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DatabaseManager();
        }

        return _instance;
    }

    public GameContext GetContext()
    {
        Console.WriteLine("Getting context...");
        if (_context != null)
        {
            Console.WriteLine("Loaded context instance!");
            return _context;
        }

        Console.WriteLine("Creating new context...");
        _context = new GameContext();
        Console.WriteLine("Context created!");
        return _context;
    }
    
    
    
}