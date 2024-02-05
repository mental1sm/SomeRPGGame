using System;

namespace Desert.Combat.Infrastructure;

/// <summary>
/// Менеджер БД
/// </summary>
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

    /// <summary>
    /// Получить экземпляр объекта без конструктора
    /// </summary>
    /// <returns>Экземпляр объекта</returns>
    public static DatabaseManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DatabaseManager();
        }

        return _instance;
    }

    /// <summary>
    /// Получает утановленный контекст БД, с чего начинается вся работа Entity Framework
    /// </summary>
    /// <returns>Установленный контекст БД</returns>
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