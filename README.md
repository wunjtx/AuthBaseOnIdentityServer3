# IdentityServer3.Sample
Identity Server Sample Code.a

selfhost webapi.

implement client credentials mode and implicit mode.

tips:
you can find these in different solution
1, client credentials mode: 
client <--> Identity Server
IS3.Sample.ClientAuth(hard code client and scope)
2, implicit mode:
user(througn web and js) <---> client <---> Identity Server
IS3.Sample.UserAuth(hard code user client and scope)
3, user client and scope with EF
IS3.Sample.EFAuth
