using System;
public class Assignment
{
    public String assignment_name;
    public String description;
    public String dueDate;
    public String link;
    public float weight;

    public Assignment(string assignment_name, string description, string dueDate, string link, float weight)
    {
        this.assignment_name = assignment_name;
        this.description = description;
        this.dueDate = dueDate;
        this.link = link;
        this.weight = weight;
    }

    public Assignment()
    {

    }
}