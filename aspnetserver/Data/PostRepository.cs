using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    public static class PostRepository
    {
        public async static Task<List<Post>> GetPostsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.ToListAsync();
            }
        }

        public async static Task<Post> GetPostsAsyncById(int postId)
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.FirstOrDefaultAsync(post => post.PostId == postId);
            }
        }

        public async static Task<bool> CreatePostsAsync(Post postToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                     await db.Posts.AddAsync(postToCreate);
                     return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                    
                }
            }
        }

        public async static Task<bool> UpdatePostsAsync(Post postToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Posts.Update(postToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;

                }
            }
        }

        public async static Task<bool> DeletePostsAsync(int postId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    var postToDelete = await GetPostsAsyncById(postId);
                    db.Remove(postToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;

                }
            }
        }
    }
}
