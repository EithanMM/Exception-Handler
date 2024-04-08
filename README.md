# Exception Handler

This small project was created with the purpose of demosntrate a 
real world approach to build a custom base class that every controller should
inherit in order to create a better exception handler approach

## Contents
For this project we used
- Common result response wrapper
- Creation of extension methods
- Creation of custom API Controller base to handle exceptions
- Multiple sutom exceptions
- Custom exception structure
- Implementation of custom configuration depending of layer
- Implementation of service & interface to repplicate a result response that contains an exception

## project Structure

### -> Web Layer
Where the controllers & initial API configuration will be located

### -> Core Layer
Where the services interfaces 
will be located, as well as the custom exceptions, response models & the response wrapper

### -> Data Layer
Where the data configuration will be located, along with the service logic & some extensions
