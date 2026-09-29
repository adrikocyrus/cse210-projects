class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Top 10 Budget Headphones", "TechTalk Daily", 845);
        video1.AddComment(new Comment("Alice", "Great list! Love number three."));
        video1.AddComment(new Comment("Bob", "Where can I buy the second pair?"));
        video1.AddComment(new Comment("Carla", "The sound test was so helpful."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Morning Workout Routine", "FitLife Amy", 612);
        video2.AddComment(new Comment("Derek", "Tried it today and I'm sore!"));
        video2.AddComment(new Comment("Elena", "What water bottle is that?"));
        video2.AddComment(new Comment("Farid", "Subscribed! Do leg day next."));
        video2.AddComment(new Comment("Grace", "Perfect for beginners."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Camping Tents Under $200", "Wild Trails", 1230);
        video3.AddComment(new Comment("Henry", "That tent survived a storm."));
        video3.AddComment(new Comment("Isabel", "Thanks for the weight details."));
        video3.AddComment(new Comment("Jamal", "Please review sleeping bags!"));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("15-Minute Dinner Recipes", "Chef Marco", 930);
        video4.AddComment(new Comment("Kim", "Made the pasta, family loved it!"));
        video4.AddComment(new Comment("Liam", "That pan looks amazing. Brand?"));
        video4.AddComment(new Comment("Mona", "Quick and simple, thank you."));
        videos.Add(video4);

        // Display every video and its comments
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            video.DisplayInfo();
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                comment.DisplayComment();
            }

            Console.WriteLine();
        }
    }
}