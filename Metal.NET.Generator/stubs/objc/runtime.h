#pragma once
struct objc_class;
struct objc_object { struct objc_class *isa; };
typedef struct objc_class *Class;
typedef struct objc_object *id;
typedef struct objc_selector *SEL;
typedef signed char BOOL;
typedef id (*IMP)(id, SEL, ...);
typedef struct objc_method *Method;
typedef struct objc_ivar *Ivar;
typedef struct objc_category *Category;
typedef struct objc_property *objc_property_t;
#ifdef __cplusplus
extern "C" {
#endif
Class objc_getClass(const char *name);
Class objc_lookUpClass(const char *name);
SEL sel_registerName(const char *str);
id objc_msgSend(id self, SEL op, ...);
void objc_msgSend_stret(void *stret, id self, SEL op, ...);
double objc_msgSend_fpret(id self, SEL op, ...);
Class object_getClass(id obj);
const char *class_getName(Class cls);
Method class_getInstanceMethod(Class cls, SEL name);
IMP method_getImplementation(Method m);
void method_setImplementation(Method m, IMP imp);
BOOL class_addMethod(Class cls, SEL name, IMP imp, const char *types);
Class objc_allocateClassPair(Class superclass, const char *name, unsigned long extraBytes);
void objc_registerClassPair(Class cls);
id objc_retain(id value);
void objc_release(id value);
id objc_autorelease(id value);
void objc_autoreleasePoolPop(void *pool);
void *objc_autoreleasePoolPush(void);
#ifdef __cplusplus
}
#endif
