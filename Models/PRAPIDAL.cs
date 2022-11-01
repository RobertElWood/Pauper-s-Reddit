using RestSharp;

namespace RedditLab.Models
{
    public class PRAPIDAL
    {
        public Subreddit GetSubreddit()
        {
            var client = new RestClient("https://www.reddit.com/r/aww/.json");
            var request = new RestRequest();
            var response = client.GetAsync<Subreddit>(request);
            Subreddit sr = response.Result;

            return sr;
        }

        public Child[] GetSubData(Subreddit sub)
        {
            Data subData = sub.data;
            Child[] postList = subData.children;

            return postList;
        }

        public Child GetPost(int index)
        {
            Subreddit sub = GetSubreddit();
            Child[] postList = GetSubData(sub);
            Child post = postList[index];
            return post;
        }
    }
}
