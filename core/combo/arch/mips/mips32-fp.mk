# Configuration for Android on MIPS.
# Generating binaries for MIPS32/hard-float/little-endian

ARCH_MIPS_HAS_FPU	:=true
ARCH_HAVE_ALIGNED_DOUBLES :=true
arch_variant_cflags := \
    -mips32 \
    -mfp32 \
    -modd-spreg \
<<<<<<< HEAD
=======
    -mno-synci
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

arch_variant_ldflags := \
    -Wl,-melf32ltsmip
