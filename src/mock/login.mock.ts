/**
 * data for Auth/login
 */
export const LOGIN_RESPONSE = {
  data: {
    firstname: 'فرشید',
    lastname: 'منوچهری',
    image: '',
    token:
      'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMTIzNDU2IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc2lkIjoiMTIzNDUiLCJ1c2VyX3R5cGUiOiJjYW5kaWRhdGUiLCJzZXNzaW9uX2lkIjoiZmQzNDU4NTYtMmU2Mi00MzE0LWFmNDUtN2UxMmZkNmFlZDNhIiwiYm9va2xldF9pZCI6IjhkNzczNjA0LTYyZTktNDM2Ni1hODY1LTBiYzkyNTZiMWYwYyIsImV4cCI6MTc2MjcxNzM4MSwiaXNzIjoiaVNhbWZhIiwiYXVkIjoic2FtZmEtY2xpZW50In0.epdW86-zEtrmkHHFbvhwkYfAX3hUha4lk4wt8hs5Lgw',
  },
  isSuccessful: true,
  message: null,
  statusCode: 200,
};

export type LoginResponse = typeof LOGIN_RESPONSE;
