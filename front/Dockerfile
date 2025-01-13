# Install dependencies only when needed
FROM node:18 AS builder
WORKDIR /app
COPY package*.json ./
RUN npm install

# Copy the application source
COPY . .

# Build the application for production
RUN npm run build

# Use a smaller base image for production
FROM node:18-alpine AS runner
WORKDIR /app
COPY --from=builder /app/.next ./.next
COPY --from=builder /app/package.json ./package.json

# Install production dependencies only
RUN npm install --production

# Expose port
EXPOSE 3000

# Start the application
CMD ["npm", "start"]
