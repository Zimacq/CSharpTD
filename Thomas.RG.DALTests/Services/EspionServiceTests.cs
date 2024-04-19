using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Thomas.RG.DAL.Models;
using Thomas.RG.DAL.Services;
using Xunit;

public class EspionServiceTests
{
    private readonly Mock<IApplicationDbContext> _mockContext;
    private readonly EspionService _service;

    public EspionServiceTests()
    {
        _mockContext = new Mock<IApplicationDbContext>();
        _service = new EspionService(_mockContext.Object);
    }
}
