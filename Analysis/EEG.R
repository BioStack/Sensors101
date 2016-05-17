args<-commandArgs(TRUE)

# Append local library
.libPaths( c( .libPaths(), "./lib") )
library(signal)
library(pracma)
library(wmtsa)
library(oce)

dataFile <- "../Data/Mindwave/test.filtered.csv"

if( length(args) == 1 )
{
	dataFile <- args[1]
}

f.results <- read.table(args, header=TRUE, sep=",")

# Get signal
x = f.results$Time
y = f.results$Value
max_y = max(y)

#eegSignal = ts(data=y, frequency=1/5)

# Draw original signal
#plot(x, y, type="l", ylim=range(-1.5*max_y,1.5*max_y,5), lwd = 1, col = "green")
plot(y, type="l")

# Construct a band-pass filter using a butterworth filter design.
# (alpha: 8-12hz, beta 12-30 hz, gamma 30-80hz, delta 0-4 hz, theta 4-8 hz)
bf_alpha <- butter(2, c(8/1000,12/1000), type="pass")
bf_beta <- butter(2, c(12/1000,30/1000), type="pass")
bf_gamma <- butter(2, c(30/1000,80/1000), type="pass")
bf_delta <- butter(2, c(0,4/1000), type="pass")
bf_theta <- butter(2, c(4/1000,8/1000), type="pass")


alpha <- signal:::filter(bf_alpha, y)
beta  <- signal:::filter(bf_beta, y)
gamma <- signal:::filter(bf_gamma, y)
delta <- signal:::filter(bf_delta, y)
theta <- signal:::filter(bf_theta, y)

plot(alpha)
plot(beta)
plot(gamma)
plot(delta)
plot(theta)

pwelch(y)