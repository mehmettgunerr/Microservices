using MassTransit;
using MicroCloud.Services.Basket.Dtos;
using MicroCloud.Services.Basket.Services;
using MicroCloud.Shared.Messages;
using MicroCloud.Shared.Services;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MicroCloud.Services.Basket.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly RedisService _redisService;

        public CourseNameChangedEventConsumer(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var allKeys = _redisService.GetAllKeys();

            if (allKeys.Count > 0)
            {
                foreach (var item in allKeys)
                {
                    var existBasket = await _redisService.GetDb().StringGetAsync(item);

                    if (!string.IsNullOrWhiteSpace(existBasket))
                    {
                        var basketData = JsonSerializer.Deserialize<BasketDto>(existBasket);

                        if (basketData.BasketItems.Any(x=>x.CourseId == context.Message.CourseId))
                        {
                            basketData.BasketItems.ForEach(x =>
                            {
                                if (x.CourseId == context.Message.CourseId)
                                {
                                    x.CourseName = context.Message.UpdatedName;
                                }
                            });

                            await _redisService.GetDb().StringSetAsync(item, JsonSerializer.Serialize(basketData));
                        }
                    }
                }
            }
        }
    }
}
