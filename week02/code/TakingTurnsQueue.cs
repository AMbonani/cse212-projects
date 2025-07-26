public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Dequeue the next person
        Person person = _people.Dequeue();

        // Create a copy to return (to keep original turns intact for tests)
        Person result = new Person(person.Name, person.Turns);

        if (person.Turns > 1)
        {
            // Decrement turns and re-enqueue
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        else if (person.Turns <= 0)
        {
            // Infinite turns: re-enqueue as-is (do NOT decrement turns)
            _people.Enqueue(person);
        }
        // else: turns == 1, this is the last turn, do NOT re-enqueue

        return result;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
