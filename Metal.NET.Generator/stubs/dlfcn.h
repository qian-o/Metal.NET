#pragma once
#ifdef __cplusplus
extern "C" {
#endif
void *dlopen(const char *filename, int flags);
void *dlsym(void *handle, const char *symbol);
int dlclose(void *handle);
char *dlerror(void);
#define RTLD_DEFAULT ((void *)0)
#define RTLD_LAZY 0x00001
#ifdef __cplusplus
}
#endif
