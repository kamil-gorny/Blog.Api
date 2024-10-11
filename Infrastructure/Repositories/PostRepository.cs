using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blog.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly IMongoCollection<Post> _products;
    private readonly IConfiguration _configuration;

    public PostRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        var client = new MongoClient(_configuration.GetConnectionString("BlogDb"));
        var database = client.GetDatabase("blog");
        _products = database.GetCollection<Post>("posts");
    }

    public async Task<Post?> GetByIdAsync(Guid id)
    { 
        return await _products.Find(product => product.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        var posts = await _products.Find(_ => true).ToListAsync();
        return posts;
    }

    public async Task<Guid> CreateAsync(Post post)
    {
        await _products.InsertOneAsync(post);
        return post.Id;
    }
}