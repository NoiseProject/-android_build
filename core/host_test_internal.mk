#####################################################
## Shared definitions for all host test compilations.
#####################################################

<<<<<<< HEAD
ifeq ($(HOST_OS),windows)
LOCAL_CFLAGS += -DGTEST_OS_WINDOWS
else
LOCAL_CFLAGS += -DGTEST_OS_LINUX
LOCAL_LDLIBS += -lpthread
endif
=======
LOCAL_CFLAGS_windows += -DGTEST_OS_WINDOWS
LOCAL_CFLAGS_linux += -DGTEST_OS_LINUX
LOCAL_LDLIBS_linux += -lpthread
LOCAL_CFLAGS_darwin += -DGTEST_OS_LINUX
LOCAL_LDLIBS_darwin += -lpthread
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

LOCAL_CFLAGS += -DGTEST_HAS_STD_STRING -O0 -g
LOCAL_C_INCLUDES +=  external/gtest/include

<<<<<<< HEAD
LOCAL_STATIC_LIBRARIES += libgtest_host libgtest_main_host
=======
LOCAL_STATIC_LIBRARIES += libgtest_main_host libgtest_host
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
