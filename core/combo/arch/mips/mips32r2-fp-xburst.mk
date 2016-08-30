# Configuration for Android on Ingenic xb4780/Xburst MIPS CPU.
# Generating binaries for MIPS32R2/hard-float/little-endian without
# support for the Madd family of instructions.

ARCH_MIPS_HAS_FPU :=true
ARCH_HAVE_ALIGNED_DOUBLES :=true
arch_variant_cflags := \
    -mips32r2 \
    -mfp32 \
    -modd-spreg \
    -mno-fused-madd \
<<<<<<< HEAD
    -Wa,-mmxu
=======
    -Wa,-mmxu \
    -mno-synci
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

arch_variant_ldflags := \
    -Wl,-melf32ltsmip
