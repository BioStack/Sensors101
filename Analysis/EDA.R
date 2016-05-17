# Append local library
.libPaths( c( .libPaths(), "./lib") )
library(signal)
library(pracma)
library(wmtsa)

f.results <- read.table("EDA.csv", header=TRUE, sep=",")

# Get signal
x = f.results$time
y = f.results$gsr
max_y = max(y)


edaSignal = ts(data=y, frequency=1/5)

# Draw original signal
plot(x, y, type="l", ylim=range(-1.5*max_y,1.5*max_y,5), lwd = 1, col = "green")

# Construct a low and high-pass filter using a butterworth filter design.
bf_low <- butter(2, 1/20, type="low")
bf_high <- butter(2, 1/20, type="high")

phasic <- signal:::filter(bf_high, edaSignal)
tonic <- signal:::filter(bf_low, edaSignal)
# 20 => circle. See http://sape.inf.usi.ch/quick-reference/ggplot2/shape

#lines(x, phasic, col="red", pch=20)
#points(x, tonic, col="blue", pch=20)



plot(tonic)

plot(phasic)

signal <- phasic 
# Get Continuous Wavelet Transform of eda signal.
edaSignal.cwt <- wavCWT(signal)
plot(edaSignal.cwt, series=TRUE)
plot(edaSignal.cwt, type="persp")


#http://stackoverflow.com/questions/16341717/detecting-cycle-maxima-peaks-in-noisy-time-series-in-r
#W <- wavCWT(linchirp)
W <- edaSignal.cwt

# tree
z <- wavCWTTree(W)

# peaks (snr.min: the minimum allowed peak signal-to-noise ratio. Default: 3.)
p <- wavCWTPeaks(z,snr.min=0.1)

#x <- as(linchirp@positions,"numeric")
#y <- linchirp@data
plot(x, signal, type="l", xlab="time", ylab="signal")

peakX = x[attr(p, which="peaks")[,"iendtime"]]
peakY = signal[attr(p, which="peaks")[,"iendtime"]]

points(x=peakX, y=peakY, pch=16, col="red", cex=1.2)

# http://affect.media.mit.edu/pdfs/15.Taylor-Jaques-et-al-ArtifactDetectionEDA.pdf
# http://affect.media.mit.edu/pdfs/12.Sano_ESRS2012.pdf
