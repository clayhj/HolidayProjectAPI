# HolidayProjectAPI
A simple API which returns holiday data

**Building/Running**
- Clone the repository to Visual Studio. 
- With the project open in Visual Studio click Build > Build Solution.
- With a successful build click Debug > Start Debugging. This will open an instance of Swagger allowing you to run the api calls.
- With Swagger open, click the call you wish to run then click "Try it out".
- Input the date or year in the correct format as explained below

**Endpoints**  
  
<ins>/holiday</ins>  
This calls [GetHoliday](https://github.com/clayhj/HolidayProjectAPI/blob/136aeb616e45a7eee2dfa2f9e979ea7e336cda5d/HolidayProjectAPI/Controllers/HolidayController.cs#L31-L46)
which accepts a date in ISO 8601 format and returns a single holiday matching the input date in a JSON string format. The JSON string contains the Holiday's name, description,
date, and if it is a floating holiday. If a match is not found it will return an empty/default Holiday in a JSON string format.  
  
<ins>/holiday/year</ins>  
This calls [GetHolidayByYear](https://github.com/clayhj/HolidayProjectAPI/blob/136aeb616e45a7eee2dfa2f9e979ea7e336cda5d/HolidayProjectAPI/Controllers/HolidayController.cs#L53-L70)
which accepts a string year in a four digit format, ex. 2021, and returns all holidays in the given year in a JSON string array format. If a matching year is not found then
it will return an empty array.  
  
**Unit Testing**  
  
Unit testing can be done in Visual Studio by clicking Test > Run All Tests. The tests assert that the API calls return ok and that they return expected data.
The tests can be found [here](https://github.com/clayhj/HolidayProjectAPI/blob/136aeb616e45a7eee2dfa2f9e979ea7e336cda5d/HolidayProjectApi.Tests/HolidayControllerTest.cs#L22-L46).  

**External Libraries**  
- Microsoft.Data.SqLite used for interaction with the SqLite database
- Newtonsoft.Json used to Serialize/Deserialize objects for JSON format
- Swashbuckle.ASPNetCore used for the Swagger interface to more easily test api calls
- XUnit used for unit testing.

**Feedback**  
  
I enjoyed working on this project, I haven't had to build an API from scratch since college and there were a few things I had to learn brand new, like SqLite and XUnit, so that
was fun. The instructions were clear and not difficult to understand. 

**Time Spent**
  
I would estimate that I've spent about 10-12 hours total which includes research time, creation, and testing.  
  
**Assumptions**
  
The assumptions I had to make in the beginning was how the project would be run/tested and what the descriptions would be for the Holidays. During our interview those were
the two questions I had asked about to get a better understanding of the requirement.  
The other assumption I'm making is that the date and year inputs are being checked/handled on the front end so that no bad inputs are sent to the API.
  
**Problems**  
  
I wouldn't necessarily call this a problem, but it was something I had to overcome which was that I didn't know how to use SqLite. I had to take time to research how to
create a SqLite database and use it in my API, and then how to include it in my project so that it can be usable as soon as it is pulled from my repository.  
  
**Enhancements**  
  
If I had more time to work on this project I would spend it adding another API call so I could use to show the use of a custom method in my HolidayRepository/Service since
currently I'm using the inherited Get and GetMany methods. I could add a method to get holiday by name for example. Another enhancement I would have liked to do would be to create
some kind of front-end which could send the API call and display the results. That would also show how the inputs could be handled before being sent to the API so no bad inputs get sent.
