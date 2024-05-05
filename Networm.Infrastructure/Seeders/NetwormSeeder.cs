using Networm.Domain.Entities;
using Networm.Infrastructure.Persistence;

namespace Networm.Infrastructure.Seeders
{
    public class NetwormSeeder
    {
        public readonly NetwormBookDbContext _networmBookDbContext;

        public NetwormSeeder(NetwormBookDbContext dbContext) 
        {
            _networmBookDbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _networmBookDbContext.Database.CanConnectAsync())
            {
                if (!_networmBookDbContext.NetwormBooks.Any())
                {
                    var networmBook = new NetwormBook();
                    networmBook.Title = "Test Book";
                    networmBook.EncodeTitle();
                    networmBook.UserName = "TestUser";

                    _networmBookDbContext.NetwormBooks.Add(networmBook);
                    await _networmBookDbContext.SaveChangesAsync();

                    var networmBookmark = new NetwormBookmark();
                    networmBookmark.NetwormBookId = networmBook.Id;
                    networmBookmark.Name = "TestName";
                    networmBookmark.HttpAdress = "http:\\test.com\\adress";
                    networmBookmark.NetwormBook = networmBook;

                    var seedBookmarkTest = new NetwormBookmark();
                    seedBookmarkTest.NetwormBookId = networmBook.Id;
                    seedBookmarkTest.Name = "TestNameTwo";
                    seedBookmarkTest.HttpAdress = "http:\\test.com\\adress";
                    seedBookmarkTest.NetwormBook = networmBook;

                    networmBook.Bookmarks?.Add(networmBookmark);
                    networmBook.Bookmarks?.Add(seedBookmarkTest);
                    
                    await _networmBookDbContext.SaveChangesAsync();
                }
            }
        }

    }
}
