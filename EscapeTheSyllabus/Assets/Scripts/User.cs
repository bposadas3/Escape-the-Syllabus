using System;
public class User
{
    public String email;
    public String firstName;
    public String lastName;
    public float grade;
    public String ownedCharacters;
    public String ownedItems;
    public String party;
    public String password;
    public String userId;
    public float year;

    public User(string email, string firstName, string lastName, float grade, string ownedCharacters, string ownedItems, string party, string password, string userId, float year)
    {
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.grade = grade;
        this.ownedCharacters = ownedCharacters;
        this.ownedItems = ownedItems;
        this.party = party;
        this.password = password;
        this.userId = userId;
        this.year = year;
    }

    public User()
    {

    }
}