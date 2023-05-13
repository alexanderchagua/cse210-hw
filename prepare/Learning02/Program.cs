using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "food engeniere";
        job1._company = "yamboly";
        job1._startYear = 2019;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "sazon norteño";
        job2._startYear = 2018;
        job2._endYear = 2019;

        Resume myResume = new Resume();
        myResume._name = "Alex Chagua";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}