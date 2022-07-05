
using StoreModel;
using Xunit;

namespace StoreTest;

    public class StoreTest
    {
        //This is how C#/XUnit recognizes that this particular method will be a unit test
        //Data annotations - They just add special metadata information that gives special properties to a particular class member

        /// <summary>
        /// Checks the validation for PokeId and sets with valid data (validData > 0)
        /// </summary>
        [Fact]
        public void uID_Should_Set_ValidData()
        {
            //Arrange
            Products uIDObj = new Products();
            int uId = 28;

            //Act
            uIDObj.uID = uId;

            //Assert
            Assert.NotNull(uIDObj.uID); 
            Assert.Equal(uId, uIDObj.uID); 
        }


        /// <summary>
        /// Checks the validation for PokeId and checks if it fails (invalidData < 0)
        /// </summary>
        /// <param name="p_uID">The inline data being given</param>
        [Theory]
        [InlineData(-19)]
        [InlineData(-1290)]
        [InlineData(0)]
        [InlineData(-12983)]
        public void MedId_Should_Fail_Set_InvalidData(int p_uID)
        {
            //Arrange
            Products uIDObj = new Products();

            //Act & Assert
            Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() => 
                {
                    uIDObj.uID = p_uID;
                }
            );
        }
    }
