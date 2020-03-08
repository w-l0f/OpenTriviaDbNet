# OpenTriviaDbNet
.net standard api for open trivia database https://opentdb.com/

## Example
```
// create api instance
var api = new OpenTriviaDbNetApi();
```
```
// session token ensures unique questions
await api.CreateSessionToken();
```
```
// get 10 questions
var questions = await api.GetQuestions(10);
```