select * 
from Users
join Places on Users.Id = Places.UserId
join Links on Links.PlaceId = Places.Id