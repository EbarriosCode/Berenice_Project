using albumes.api.Controllers;
using albumes.application.DTO;
using albumes.application.Handlers.Albumes;
using albumes.models.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace albumes.tests.albumes.api.Controllers.Albumes
{
    public class AlbumesControllerTests
    {
        private readonly Mock<IAlbumesHandler> _handler;

        public AlbumesControllerTests() => this._handler = new Mock<IAlbumesHandler>();

        #region Get-List-Of-Albumes
        [Fact]
        public async Task Get_Albumes_Return_Ok()
        {
            // Arrange
            this._handler.Setup(x => x.GetAlbumes())
                         .Returns(Task.FromResult(
                             new Album[] 
                             {
                                new Album
                                {
                                    ArtistID = 1,
                                    Title = "Santo Pecado",
                                    Price = 125.00,
                                    Date = new DateTime(2002, 11, 19),
                                    AvailableToPurchase = false
                                },
                                new Album
                                {
                                    ArtistID = 1,
                                    Title = "Circo Soledad",
                                    Price = 155.00,
                                    Date = new DateTime(2017, 4, 21),
                                    AvailableToPurchase = true
                                },
                                new Album
                                {
                                    ArtistID = 2,
                                    Title = "My Way",
                                    Price = 205.00,
                                    Date = new DateTime(1969, 5, 2),
                                    AvailableToPurchase = true
                                }
                             }));

            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }
        #endregion Get-List-Of-Albumes

        #region Get-Album-By-ID
        [Fact]
        public async Task Get_Album_By_Id_Return_Ok()
        {
            // Arrange
            this._handler.Setup(x => x.GetAlbumById(It.IsAny<int>()))
                         .Returns(Task.FromResult(
                             new Album
                             {
                                ArtistID = 2,
                                Title = "My Way",
                                Price = 205.00,
                                Date = new DateTime(1969, 5, 2),
                                AvailableToPurchase = true                                
                             }));

            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Get(2);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task Get_Album_By_Id_Zero_Return_BadRequest()
        {
            // Arrange           
            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Get(0);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task Get_Album_By_Id_Return_NotFound()
        {
            // Arrange            
            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Get(100);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }
        #endregion Get-Album-By-ID

        #region Post-Album
        [Fact]
        public async Task Post_Album_Return_Created()
        {
            // Arrange
            this._handler.Setup(x => x.CreateAlbumAsync(It.IsAny<Album>()))
                         .Returns(Task.FromResult(
                             new Album
                             {
                                 ArtistID = 1,
                                 Title = "My Way",
                                 Price = 205.00,
                                 Date = new DateTime(1969, 5, 2),
                                 AvailableToPurchase = true
                             }));

            var controller = new AlbumesController(null, this._handler.Object);
            
            // Act
            var result = await controller.Post(new AlbumDTO());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public async Task Post_Album_Return_BadRequest()
        {
            // Arrange            
            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Post(null);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
        #endregion Post-Album

        #region Put-Album
        [Fact]
        public async Task Put_Album_Return_Updated_NoContent()
        {
            // Arrange            
            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Put(new AlbumDTO());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Put_Album_Return_BadRequest()
        {
            // Arrange            
            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Put(new AlbumDTO());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }
        #endregion Put-Album

        #region Delete-Album
        [Fact]
        public async Task Delete_Album_Return_Deleted_NoContent()
        {
            // Arrange
            this._handler.Setup(x => x.GetAlbumById(It.IsAny<int>()))
                         .Returns(Task.FromResult(
                             new Album
                             {
                                 ArtistID = 2,
                                 Title = "My Way",
                                 Price = 205.00,
                                 Date = new DateTime(1969, 5, 2),
                                 AvailableToPurchase = true
                             }));

            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Delete(2);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_Album_By_Id_Zero_Return_BadRequest()
        {
            // Arrange           
            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Delete(0);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_Album_With_Id_Does_Exists_Return_NotFound()
        {
            // Arrange            
            var controller = new AlbumesController(null, this._handler.Object);

            // Act
            var result = await controller.Delete(100);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion Delete-Album
    }
}
